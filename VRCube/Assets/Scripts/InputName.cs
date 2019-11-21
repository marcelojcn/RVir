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

        var input = inputField.GetComponent<Text>().text;
        if (!string.IsNullOrWhiteSpace(input))
        {
            Manager.GetComponent<GameManager>().theName = input;
        };
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

