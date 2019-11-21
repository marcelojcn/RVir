using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    private float timeLeft = 60.0f;
    public Text timer;

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = "Time left: " + (timeLeft).ToString("0");
        if (timeLeft <= 0)
            GameOver();
    }

    private void GameOver()
    {
        SceneManager.LoadScene(1); 
    }
}
