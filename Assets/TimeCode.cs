using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeCode : MonoBehaviour
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
        if (text == null)
        {
            text = CreateText();
        }

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

    // Cr�e le TextMeshProUGUI
    TextMeshProUGUI CreateText()
    {
        // Cr�e un nouveau TextMeshProUGUI
        text = new TextMeshProUGUI();

        // D�finit la taille et la police du texte
        text.fontSize = 32;


        // Positionne le texte
        text.transform.SetParent(canvas.transform);
        text.transform.localPosition = Vector3.zero;

        // Ajoute le script au game object
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameObject.AddComponent<TimeCode>();

        // Cr�e le TextMeshProUGUI
        gameObject.GetComponent<TimeCode>().CreateText();

        return text;
    }
}