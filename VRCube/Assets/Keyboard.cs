using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject CubeController;
    public KeyboardTypeEnum keyboard;

    private void OnTriggerEnter(Collider other)
    {
        CubeController cube = CubeController.GetComponent<CubeController>();
        cube.KeyboardType = keyboard;
    }
}
