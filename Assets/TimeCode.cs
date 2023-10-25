using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeCode : MonoBehaviour
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
        if (text == null)
        {
            text = CreateText();
        }

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

    // Crée le TextMeshProUGUI
    TextMeshProUGUI CreateText()
    {
        // Crée un nouveau TextMeshProUGUI
        text = new TextMeshProUGUI();

        // Définit la taille et la police du texte
        text.fontSize = 32;


        // Positionne le texte
        text.transform.SetParent(canvas.transform);
        text.transform.localPosition = Vector3.zero;

        // Ajoute le script au game object
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameObject.AddComponent<TimeCode>();

        // Crée le TextMeshProUGUI
        gameObject.GetComponent<TimeCode>().CreateText();

        return text;
    }
}