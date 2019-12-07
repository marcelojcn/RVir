using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject Controller;
    public GameObject Manager;
    public GameObject SelectionMenu;

    private void OnTriggerEnter(Collider other)
    {
        Leave();
    }

    public void Leave() 
    {
        Controller.SetActive(false);
        var scoreController = Controller.GetComponent<ScoreController>();
        scoreController.Reset();
        scoreController.WorkdIndex = 0;
        var cubeController = Controller.GetComponent<CubeController>();
        cubeController.Reset();

        var gameManager = Manager.GetComponent<GameManager>();
        gameManager.Reset();

        SelectionMenu.SetActive(true);
    }
}
