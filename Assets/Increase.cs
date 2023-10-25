using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Increase : MonoBehaviour
{
    float score;
    private object scoretextMeshProUGUI;

    public void IncreaseScore(float amount)

    {  score += amount;

        UpdateScoreDisplay(); 
    
    }

    public void UpdateScoreDisplay()
    {
        scoretextMeshProUGUI = "score:" + score;
        scoretextMeshProUGUI = score.ToString(); 

    }
}
