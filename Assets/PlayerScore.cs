using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    public static float score;
    private float scoreValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScore.score += scoreValue;
        //Destroy(gameObject);
    }

}
    

