using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;
public class TimerController : MonoBehaviour
{
    private float _timeLeft = 60.0f;
    Text _startText;

    // Update is called once per frame
    void Update()
    {
        _timeLeft -= Time.deltaTime;

        _startText.text = "Time Left " + (_timeLeft).ToString("0");
        if (_timeLeft <= 0)
            GameOver();

    }

    private void GameOver()
    {
        SceneManager.LoadScene("IntroMenu");
    }
}
