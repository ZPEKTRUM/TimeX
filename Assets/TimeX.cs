using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeX : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    private DateTime currentTime;
    private string timeFormatted;

    private void Start()
    {
        // Start the UpdateTime() coroutine
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        while (true)
        {
            // Récupère l'heure actuelle
            currentTime = DateTime.UtcNow;

            // Formate l'heure
            timeFormatted = currentTime.ToString("yyyy-MM-dd HH:mm");

            // Attend 1 seconde
            yield return new WaitForSeconds(1);

            // Effectue une action
            Debug.Log(timeFormatted);

            // Affiche la date et l'heure actuelle dans le label
            textMeshPro.text = timeFormatted;

        
            {
                while (true)
                {
                    // Récupère l'heure actuelle
                    DateTime currentTime = DateTime.Now;

                    // Formate l'heure
                    string timeFormatted = currentTime.ToString("HH:mm");

                    // Attend 1 seconde
                    yield return new WaitForSeconds(10);

                    // Effectue une action
                    Debug.Log(timeFormatted);

                    // Affiche l'heure actuelle dans le label
                    textMeshPro.text = timeFormatted;
                }
            }

        }


    }


}