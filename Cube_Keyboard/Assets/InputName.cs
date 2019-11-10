using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Assets.Utilities;
using Assets.Utilities.Enums;
using UnityEngine.SceneManagement;


public class InputName : MonoBehaviour
{
    public GameObject inputField;
    public GameObject TextDisplay;

    public void StoreName()
    {
        GameObject Manager = GameObject.Find("Manager");
        Manager.GetComponent<GameManager>().theName = inputField.GetComponent<Text>().text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

