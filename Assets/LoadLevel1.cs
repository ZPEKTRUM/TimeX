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
        // D�marre le timer
        loadTimer = 0.0f;

        // Charge la sc�ne suivante
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MVT");
    }

    void Update()
    {
        // Incr�mente le timer
        loadTimer += Time.deltaTime;

        // Si le timer est �coul�, charge la sc�ne suivante
        if (loadTimer >= loadTime)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MVT");
        }
    }
}