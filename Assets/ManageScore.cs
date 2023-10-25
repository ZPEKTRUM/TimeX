using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageScore : MonoBehaviour
{
    public static ManageScore instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    //les variables

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //reset the counter

        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + "POINTS";
        highscoreText.text = "HIGHSCORE:" + highscore.ToString();

    }

    public void AddPoint()

    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If the player enters the trigger area, add a point to their score
        if (other.gameObject.tag == "Player")
        {
            AddPoint();
        }
    }
}
