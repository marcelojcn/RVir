using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDiacritics : MonoBehaviour
{
    private CubeController _cubeController;
    private bool _isActive = false;

    private void Start()
    {
        _cubeController = GameObject.Find("Controller").GetComponent<CubeController>();

        var key = GameObject.Find("DrumsticksKey").GetComponent<Drumstick>();
        gameObject.SetActive(!key.IsActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isActive = !_isActive;
        _cubeController.TurnOnDiacritics(_isActive);
    }


}
