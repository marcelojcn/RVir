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
    private bool _activeDiacritics = false;

    private DateTime? MouseOverTimestamp;
    private float? _exitTimestamp;
    private ScoreController _scoreController;

    private CSVLogger _logger;
    public Material OutlinedMaterial;

    private void Start()
    {
        _logger = FindObjectOfType<CSVLogger>();
        _scoreController = GameObject.Find($"Controller").gameObject.GetComponent<ScoreController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        //Fetch the Material from the Renderer of the GameObject
        GetComponent<Renderer>().material = OutlinedMaterial;

        if (string.IsNullOrWhiteSpace(value))
        { return; }

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

        if (string.IsNullOrWhiteSpace(value))
        { return; }

        if (!other.gameObject.name.Equals("DrumstickSphere"))
        {
            // If not a Diacritic and has Diacritics and Timestamp saved
            if (!IsDiacritic && Diacritics.Any() && MouseOverTimestamp.HasValue)
            {
                MouseOverTimestamp = null;
            }

            if (_activeDiacritics)
            {
                _exitTimestamp = Time.time;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (string.IsNullOrWhiteSpace(value))
        { return; }

        if (!other.gameObject.name.Equals("DrumstickSphere"))
        {
            // If not a Diacritic and has Diacritics and no Timestamp saved
            if (!IsDiacritic && Diacritics.Any() && !MouseOverTimestamp.HasValue)
            {
                // Save the timestamp of the moment the user started hovering the key
                MouseOverTimestamp = DateTime.Now;
            }

            // If it is not a diacritic and none of the diacritic were created 
            if (!IsDiacritic && Diacritics.Any() && (DateTime.Now - MouseOverTimestamp.Value).Seconds >= 1)
            {
                Diacritics.ForEach(d => d.SetActive(true));
                _activeDiacritics = true;
            }

            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                _logger.Write("Button Pressed: A");
                Write();
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.X))
            {
                _logger.Write("Button Pressed: X");
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

    public void StatusDiacritics(bool status) 
    {
        Diacritics.ForEach(d => d.SetActive(status));
        _activeDiacritics = status;
    }

    public void Clean() 
    {
        // If this Letter has Created Diacritics
        if (Diacritics.Any()) 
        {
            // Delete all
            Diacritics.ForEach(d => d.SetActive(false));
            _activeDiacritics = false;
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
