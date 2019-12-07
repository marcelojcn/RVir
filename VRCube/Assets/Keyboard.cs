using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject Controller;
    private CubeController _cubeController;
    public KeyboardTypeEnum keyboard;

    private bool _isOutlined;
    public Material OutlinedMaterial;
    private void Start() 
    {
        _cubeController = Controller.GetComponent<CubeController>();
    }

    private void Update()
    {
        if (!_isOutlined && (_cubeController.KeyboardType == keyboard))
        {
            ToggleOutlined(true);
        }
        else if (_isOutlined && (_cubeController.KeyboardType != keyboard))
        {
            ToggleOutlined(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _cubeController.KeyboardType = keyboard;
    }

    private void ToggleOutlined(bool status) 
    {
        _isOutlined = status;
        if (status)
        {
            GetComponent<Renderer>().material = OutlinedMaterial;
        }
        else 
        {
            //Fetch the Material from the Renderer of the GameObject
            Material material = GetComponent<Renderer>().material;
            material.shader = Shader.Find("Standard");
            material.renderQueue = 3000;
        }
    }
}
