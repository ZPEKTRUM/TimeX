using System;
using UnityEngine;

public class Horloge : MonoBehaviour
{
    public float rayon = 100;
    public float angleHeure = 0;
    public float angleMinute = 0;
    public float angleSeconde = 0;

    // Fonction d'initialisation
    void Start()
    {
        // Définit l'heure actuelle
        System.DateTime now = DateTime.Now;
        int heure = now.Hour;
        int minute = now.Minute;
        int seconde = now.Second;

        // Convertit l'heure en degrés
        angleHeure = (heure % 12) * 360 / 12;
        angleMinute = minute * 360 / 60;
        angleSeconde = seconde * 360 / 60;
    }

    // Fonction appelée à chaque frame
    void Update()
    {
        // Détecte la fin du décompte
        if (angleSeconde >= 360)
        {

        }
        // Affiche la date
        Debug.Log(DateTime.Now.ToString());

        // Affiche l'heure
        Debug.Log("Heure : " + heure + ":" + minute + ":" + seconde);
    }



    public float loadTime = 60.0f;
    private float loadTimer = 0.0f;
    private string heure;
    private string minute;
    private string seconde;

    public void LoadGame()
    {
        // Démarre le timer
        loadTimer = 0.0f;

        // Charge la scène suivante
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MVT");
    }

    void FixUpdate()
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
    
