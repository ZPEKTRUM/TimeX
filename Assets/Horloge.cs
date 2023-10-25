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
        // D�finit l'heure actuelle
        System.DateTime now = DateTime.Now;
        int heure = now.Hour;
        int minute = now.Minute;
        int seconde = now.Second;

        // Convertit l'heure en degr�s
        angleHeure = (heure % 12) * 360 / 12;
        angleMinute = minute * 360 / 60;
        angleSeconde = seconde * 360 / 60;
    }

    // Fonction appel�e � chaque frame
    void Update()
    {
        // D�tecte la fin du d�compte
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
        // D�marre le timer
        loadTimer = 0.0f;

        // Charge la sc�ne suivante
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MVT");
    }

    void FixUpdate()
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
    
