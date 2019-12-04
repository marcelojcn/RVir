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
        Controller.SetActive(false);
        var scoreController = Controller.GetComponent<ScoreController>();
        scoreController.Reset();
        var cubeController = Controller.GetComponent<CubeController>();
        cubeController.Reset();

        var gameManager = Manager.GetComponent<GameManager>();
        gameManager.Reset();

        SelectionMenu.SetActive(true);
    }
}
