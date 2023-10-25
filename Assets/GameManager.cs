using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;

    //les variables

    int score = 0;
    int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //reset the counter

        scoreText.text = score.ToString() + "POINTS";
        highscoreText.text = "HIGHSCORE:" + highscore.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
