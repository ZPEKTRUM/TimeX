using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CodeTime : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _text;

    // Crée un canvas
    Canvas canvas;

    // Crée un TextMeshProUGUI
    TextMeshProUGUI text;

    // Récupère l'heure actuelle
    DateTime now = DateTime.Now;

    // Initialise le canvas
    void Start()
    {
        canvas = GetComponent<Canvas>();

        // Vérifie que le composant TextMeshProUGUI existe
        text = GetComponent<TextMeshProUGUI>();

        // Si le composant n'existe pas, le crée
        

        // Démarre la coroutine
        StartCoroutine(UpdateTime());
    }

    // Affiche l'heure
    IEnumerator UpdateTime()
    {
        while (true)
        {
            // Met à jour le texte
            text.text = now.ToString();

            // Attend 1 seconde
            yield return new WaitForSeconds(1);
        }
    }

    
    }
