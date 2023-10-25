using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _txt;
    [SerializeField] TextMeshProUGUI _txtEndScreen;

    [Header("Debug")]
    [SerializeField] int _currentScore;

    public int score;
    public int currentScore; // variable, virgule flottante, ou entier pour stocker le score
    private float scoreValue;

    public static ScoreManager Instance { get; private set; }
    public float Score { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseScore(float amount)
    { Score += amount; }

    public void AddScore(int amount)
    {
        _currentScore += amount;
        _txt.text = _currentScore.ToString();
        _txtEndScreen.text = _currentScore.ToString();
    }

    public void AddTenPoints() //Augmenter le score

    {

        score += 10;

        ScoreManager.Instance.IncreaseScore(scoreValue);

    }

}