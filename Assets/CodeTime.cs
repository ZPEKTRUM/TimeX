using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CodeTime : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _text;

    // Cr�e un canvas
    Canvas canvas;

    // Cr�e un TextMeshProUGUI
    TextMeshProUGUI text;

    // R�cup�re l'heure actuelle
    DateTime now = DateTime.Now;

    // Initialise le canvas
    void Start()
    {
        canvas = GetComponent<Canvas>();

        // V�rifie que le composant TextMeshProUGUI existe
        text = GetComponent<TextMeshProUGUI>();

        // Si le composant n'existe pas, le cr�e
        

        // D�marre la coroutine
        StartCoroutine(UpdateTime());
    }

    // Affiche l'heure
    IEnumerator UpdateTime()
    {
        while (true)
        {
            // Met � jour le texte
            text.text = now.ToString();

            // Attend 1 seconde
            yield return new WaitForSeconds(1);
        }
    }

    
    }
