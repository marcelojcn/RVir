using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject Controller;

    private void OnTriggerEnter(Collider other)
    {
        Controller.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
