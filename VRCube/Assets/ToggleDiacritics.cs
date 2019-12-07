using Assets.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDiacritics : MonoBehaviour
{
    private CubeController _cubeController;
    private CSVLogger _csvLogger;
    private bool _isActive = false;
    private Drumstick _drumstick;


    private void Start()
    {
        var controller = GameObject.Find("Controller");
        _cubeController = controller.GetComponent<CubeController>();
        _csvLogger = controller.GetComponent<CSVLogger>();

        _drumstick = GameObject.Find("DrumsticksKey").GetComponent<Drumstick>();
    }

    public void Update()
    {
        if (_drumstick.IsActive) 
        {
            gameObject.SetActive(_drumstick.IsActive);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isActive = !_isActive;
        _cubeController.TurnOnDiacritics(_isActive);

        _csvLogger.Write($"Driacritics: {_isActive}");
    }


}
