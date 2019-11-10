using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEngine.UI;
public class TimerController : MonoBehaviour
{
    private float _timeLeft = 10.0f;
    public Text _startText;

    void Start()
    {

    }

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
