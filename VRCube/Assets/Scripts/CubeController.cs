using UnityEngine;
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

    public GameObject RightKeyboard;
    private GameObject _createdRightKeyboard;

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
            _createdMainKeyboard.transform.Rotate(new Vector3(30f, 0f, 0f));
        }
    }

    public void generateRightKeyboard()
    {
        Vector3 destination = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTrackedRemote) + new Vector3(-0.1f, 1.3f, -0.1f);

        if (_createdRightKeyboard != null)
        {
            _createdRightKeyboard.transform.position = destination;
        }
        else
        {
            _createdRightKeyboard = Instantiate(RightKeyboard, destination, Quaternion.identity);
            _createdRightKeyboard.transform.Rotate(new Vector3(30f, 0f, 0f));
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
            _createdLeftKeyboard.transform.Rotate(new Vector3(30f, 0f, 0f));
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
            _createdPlanarKeyboard.transform.Rotate(new Vector3(30f, 0f, 0f));
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
                if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0 && RightKeyboard != null)
                {
                    generateRightKeyboard();
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

    public void Reset()
    {
        if (_createdLeftKeyboard != null)
        {
            Destroy(_createdLeftKeyboard);
        }
        if (_createdRightKeyboard != null)
        {
            Destroy(_createdRightKeyboard);
        }
        if (_createdMainKeyboard != null)
        {
            Destroy(_createdMainKeyboard);
        }
        if (_createdPlanarKeyboard != null)
        {
            Destroy(_createdPlanarKeyboard);
        }
    }
}

public enum KeyboardTypeEnum 
{
    OneCube,
    TwoCube,
    Planar
}