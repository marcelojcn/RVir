using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Assets.Utilities;
using Assets.Utilities.Enums;

public class CubeController : MonoBehaviour
{
    public GameObject CubeKeyboard;
    private GameObject _createdKeyboard;

    public bool isCreated => _createdKeyboard != null;

    public void generateColoredCubeSquare()
    {
        Vector3 destination = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTrackedRemote) + new Vector3(-0.1f, 1.3f, -0.1f);

        if (_createdKeyboard != null)
        {
            _createdKeyboard.transform.position = destination;
        }
        else 
        {
            //mainCube.transform.position = destination;
            _createdKeyboard = Instantiate(CubeKeyboard, destination, Quaternion.identity);
        }
    }

    public void Clean() 
    {
        Destroy(_createdKeyboard);
    }

    public void Update()
    {
        if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0)
        {
            generateColoredCubeSquare();
        }

    }
}