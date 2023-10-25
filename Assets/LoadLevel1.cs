using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOne: MonoBehaviour
{

    public float loadTime = 60.0f;
    private float loadTimer = 0.0f;

    public void LoadGame()
    {
        // Démarre le timer
        loadTimer = 0.0f;

        // Charge la scène suivante
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MVT");
    }

    void Update()
    {
        // Incrémente le timer
        loadTimer += Time.deltaTime;

        // Si le timer est écoulé, charge la scène suivante
        if (loadTimer >= loadTime)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MVT");
        }
    }
}