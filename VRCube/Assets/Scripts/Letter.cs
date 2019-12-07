using Assets.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class Letter : MonoBehaviour
{
  
    public string value;
    public bool IsDiacritic;

    public List<GameObject> Diacritics;
    private List<GameObject> CreatedDiacritics;

    private DateTime? MouseOverTimestamp;
    private float? _exitTimestamp;
    //bool space = false;
    private ScoreController _scoreController;


    public Material OutlinedMaterial;

    private void Start()
    {
        CreatedDiacritics = new List<GameObject>();
        _scoreController = GameObject.Find($"Controller").gameObject.GetComponent<ScoreController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        //Fetch the Material from the Renderer of the GameObject
        GetComponent<Renderer>().material = OutlinedMaterial;

        if (other.gameObject.name.Equals("DrumstickSphere"))
        {
            Write();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Fetch the Material from the Renderer of the GameObject
        Material material = GetComponent<Renderer>().material;
        material.shader = Shader.Find("Standard");
        material.renderQueue = 3000;

        if (!other.gameObject.name.Equals("DrumstickSphere"))
        {
            // If not a Diacritic and has Diacritics and Timestamp saved
            if (!IsDiacritic && Diacritics.Any() && MouseOverTimestamp.HasValue)
            {
                MouseOverTimestamp = null;
            }

            if (CreatedDiacritics.Any())
            {
                _exitTimestamp = Time.time;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.name.Equals("DrumstickSphere"))
        {
            // If not a Diacritic and has Diacritics and no Timestamp saved
            if (!IsDiacritic && Diacritics.Any() && !MouseOverTimestamp.HasValue)
            {
                // Save the timestamp of the moment the user started hovering the key
                MouseOverTimestamp = DateTime.Now;
            }

            // If it is not a diacritic and none of the diacritic were created 
            if (!IsDiacritic && !CreatedDiacritics.Any() && Diacritics.Any() && (DateTime.Now - MouseOverTimestamp.Value).Seconds >= 1)
            {
                int index = 0;

                float spacing = 0.01f;

                // Draw Diacritics
                for (float y = (transform.position.y + (0.1f + spacing)); y >= (transform.position.y - (0.1f + spacing)); y -= (0.1f + spacing))
                {
                    // 1.09f instead of 1.08f because of float precision
                    for (float x = (transform.position.x - (0.1f + spacing)); x <= (transform.position.x + (0.1f + spacing)); x += (0.1f + spacing))
                    {
                        // Check if not drawing Diacritic over the Letter
                        if (!(x == transform.position.x && y == transform.position.y) && index < Diacritics.Count)
                        {
                            // Instantiate the Diacritic
                            GameObject newDiacritic = Instantiate(Diacritics[index], new Vector3(x, y, transform.position.z), Quaternion.identity);
                            newDiacritic.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            newDiacritic.transform.parent = transform.parent;

                            // Save the created Diacritic's object
                            CreatedDiacritics.Add(newDiacritic);

                            index++;
                        }
                    }
                }
            }


            if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.X))
            {
                Write();
            }
        }
    }
    private void Write()
    {
        // Write Letter Value
        Debug.Log(value);

        _scoreController.AddLetter(value);

        FindObjectOfType<AudioManager>().Play("Click");

        // Check if Diacritic
        if (IsDiacritic)
        {
            // Get Main Letter
            GameObject diacriticGO = GameObject.Find($"{RemoveDiacritics(value)[0]}(Clone)");
            GameObject diacriticGOGO = diacriticGO.gameObject;
            Letter letter = diacriticGOGO.GetComponent<Letter>();
            Debug.Log(RemoveDiacritics(value));
            // Clean Letter
            letter.Clean();
        }
        else
        {
            // Clean himself
            Clean();
        }
    }

    public void Clean() 
    {
        // If this Letter has Created Diacritics
        if (CreatedDiacritics.Any()) 
        {
            // Delete all
            CreatedDiacritics.ForEach(d => Destroy(d));

            // Reset CreatedDiacritics list
            CreatedDiacritics = new List<GameObject>();
        }

        // If a letter was written then clean MouseOverTimeStamp 
        MouseOverTimestamp = null;
        _exitTimestamp = null;
    }

    private void Update()
    {
        if (!IsDiacritic && _exitTimestamp.HasValue && ((Time.time - _exitTimestamp.Value) >= 1f)) 
        {
            Clean();
        }
    }

    #region Protected Methods
    protected string RemoveDiacritics(string text)
    {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
    #endregion
}
