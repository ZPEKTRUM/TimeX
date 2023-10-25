using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameOverscreen : MonoBehaviour
{

    public TextMeshProUGUI pointsText;

    public void setup(int score)


    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "POINTS";


    }


    public void RestartButton()

    {

        SceneManager.LoadScene("MVT");
    
    }

    public void ExitButton()

    {
        SceneManager.LoadScene("MENU");

            }

    public void Reset()
    {
        gameObject.SetActive(false); }
    }






