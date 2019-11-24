using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{

    public GameObject ScoreController;
    public DifficultyTypeEnum difficulty;
    
    private void OnTriggerEnter(Collider other)
    {
        ScoreController score = ScoreController.GetComponent<ScoreController>();
        score.DifficultyType = difficulty;
    }
}
