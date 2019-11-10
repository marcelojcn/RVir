using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string theName;
    public string difficulty = "easy";

    private void Awake() {
        theName = Guid.NewGuid().ToString();
        DontDestroyOnLoad(gameObject);
    }



}
