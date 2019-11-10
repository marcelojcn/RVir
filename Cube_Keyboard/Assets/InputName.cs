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
    public string theName;
    public GameObject inputField;
    public GameObject TextDisplay;

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

