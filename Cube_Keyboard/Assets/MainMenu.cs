using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    public void Play ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    //this need to pass to the next scene
    public void ChangeDifficulty(string diff)
    {
        GameObject Manager = GameObject.Find("Manager");
        Manager.GetComponent<GameManager>().difficulty = diff;
    }

}
