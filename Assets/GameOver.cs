using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI; 

public class GameOver : MonoBehaviour
{


    public TextMeshProUGUI pointsText; // cr�ation d une nouvelle variable

    public void Setup(int score) 
       
    
    {  
        
        gameObject.SetActive(true);

        pointsText.text = score.ToString() + "";
    
    
    }

         

        
}
