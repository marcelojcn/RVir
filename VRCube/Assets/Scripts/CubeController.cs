﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Assets.Utilities;
using Assets.Utilities.Enums;

public class CubeController : MonoBehaviour
{
    public GameObject MainKeyboard;
    private GameObject _createdMainKeyboard;


    public GameObject LeftKeyboard;
    private GameObject _createdLeftKeyboard;

    public GameObject PlanarKeyboard;
    private GameObject _createdPlanarKeyboard;

    public KeyboardTypeEnum KeyboardType = KeyboardTypeEnum.OneCube;

    public bool isCreated => _createdMainKeyboard != null;

    public void generateMainKeyboard()
    {
        Vector3 destination = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTrackedRemote) + new Vector3(-0.1f, 1.3f, -0.1f);

        if (_createdMainKeyboard != null)
        {
            _createdMainKeyboard.transform.position = destination;
        }
        else 
        {
            _createdMainKeyboard = Instantiate(MainKeyboard, destination, Quaternion.identity);
        }
    }


    public void generateLeftKeyboard()
    {
        Vector3 destination = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTrackedRemote) + new Vector3(-0.1f, 1.3f, -0.1f);

        if (_createdLeftKeyboard != null)
        {
            _createdLeftKeyboard.transform.position = destination;
        }
        else
        {
            _createdLeftKeyboard = Instantiate(LeftKeyboard, destination, Quaternion.identity);
        }
    }


    public void generatePlanarKeyboard()
    {
        Vector3 destination = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTrackedRemote) + new Vector3(-0.1f, 1.3f, -0.1f);

        if (_createdPlanarKeyboard != null)
        {
            _createdPlanarKeyboard.transform.position = destination;
        }
        else
        {
            _createdPlanarKeyboard = Instantiate(PlanarKeyboard, destination, Quaternion.identity);
        }
    }

    public void Clean() 
    {
        Destroy(_createdMainKeyboard);
    }

    public void Update()
    {
        switch (KeyboardType) 
        {
            case KeyboardTypeEnum.OneCube:
                if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0 && MainKeyboard != null)
                {
                    generateMainKeyboard();
                }

                break;
            case KeyboardTypeEnum.TwoCube:
                if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0 && MainKeyboard != null)
                {
                    generateMainKeyboard();
                }

                if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > 0 && LeftKeyboard != null)
                {
                    generateLeftKeyboard();
                }
                break;
            case KeyboardTypeEnum.Planar:
                if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0 && PlanarKeyboard != null)
                {
                    generatePlanarKeyboard();
                }
                break;
        }


        

    }
}

public enum KeyboardTypeEnum 
{
    OneCube,
    TwoCube,
    Planar
}