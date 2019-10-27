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

    private void Start()
    {
        CreatedDiacritics = new List<GameObject>();
    }

    private void OnMouseEnter() 
    {
        //Fetch the Material from the Renderer of the GameObject
        Material material = GetComponent<Renderer>().material;
        material.shader = Shader.Find("Outlined/Uniform");
    }

    private void OnMouseExit()
    {
        //Fetch the Material from the Renderer of the GameObject
        Material material = GetComponent<Renderer>().material;
        material.shader = Shader.Find("Standard");

        // If not a Diacritic and has Diacritics and Timestamp saved
        if (!IsDiacritic && Diacritics.Any() && MouseOverTimestamp.HasValue)
        {
            MouseOverTimestamp = null;
        }
    }

    private void OnMouseOver()
    {
        // If not a Diacritic and has Diacritics and no Timestamp saved
        if (!IsDiacritic && Diacritics.Any() && !MouseOverTimestamp.HasValue)
        {
            // Save the timestamp of the moment the user started hovering the key
            MouseOverTimestamp = DateTime.Now;
        }

        // If it is not a diacritic and none of the diacritic were created 
        if (!IsDiacritic && !CreatedDiacritics.Any() && Diacritics.Any() && (DateTime.Now - MouseOverTimestamp.Value).Seconds >= 2)
        {
            int index = 0;

            // Draw Diacritics
            for (float y = (transform.position.y + 1.08f); y >= (transform.position.y - 1.08f); y -= 1.08f)
            {
                // 1.09f instead of 1.08f because of float precision
                for (float x = (transform.position.x - 1.08f); x <= (transform.position.x + 1.09f); x += 1.08f)
                {
                    // Check if not drawing Diacritic over the Letter
                    if (!(x == transform.position.x && y == transform.position.y) && index < Diacritics.Count) 
                    {
                        // Instantiate the Diacritic
                        GameObject newDiacritic = Instantiate(Diacritics[index], new Vector3(x, y, transform.position.z), Quaternion.identity);

                        // Save the created Diacritic's object
                        CreatedDiacritics.Add(newDiacritic);

                        index++;
                    }
                }
            }
        }
    }
    private void OnMouseDown()
    {
        // Write Letter Value
        Debug.Log(value);
        
        // Get Text object
        Text text = GameObject.Find($"Text").gameObject.GetComponent<Text>();
        // Add letter
        text.text = text.text + value;


        // Check if Diacritic
        if (IsDiacritic)
        {
            // Get Main Letter
            Letter letter = GameObject.Find($"{RemoveDiacritics(value)}(Clone)").gameObject.GetComponent<Letter>();

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
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Get object render
            Renderer renderer = GetComponent<Renderer>();
            
            // toggle visibility:
            renderer.enabled = !renderer.enabled;

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
