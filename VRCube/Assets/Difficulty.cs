using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{

    public GameObject ScoreController;
    
    
    private void OnTriggerEnter(Collider other)
    {
        ScoreController score = ScoreController.GetComponent<ScoreController>();
        
    }
}
