using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drumstick : MonoBehaviour
{
    public GameObject RightDrumstick;
    public GameObject LeftDrumstick;

    public GameObject RightSphere;
    public GameObject LeftSphere;

    public bool IsActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsActive)
        {
            RightDrumstick.SetActive(true);
            LeftDrumstick.SetActive(true);
            RightSphere.SetActive(false);
            LeftSphere.SetActive(false);

            IsActive = true;
        }
        else
        {
            RightDrumstick.SetActive(false);
            LeftDrumstick.SetActive(false);
            RightSphere.SetActive(true);
            LeftSphere.SetActive(true);

            IsActive = false;
        }
    }
}
