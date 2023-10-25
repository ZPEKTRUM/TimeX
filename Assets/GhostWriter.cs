using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ghostwriter : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public TextMeshProUGUI textMesh;
    public TextAsset[] phrases;
    public int phraseIndex = 0;

    /// <summary>
    /// Temps d'affichage de la phrase.
    /// </summary>
    [SerializeField]
    public float stopWritingAfter = 10.0f;

    [SerializeField] AudioClip audioClip;


    private AudioSource audioSource;

    // Interface pour interagir avec le joueur
    [SerializeField]
    public QuestionAnswerInterface interfaceGame;

    public void AskQuestion(string question)
    {
        // Afficher la question
        interfaceGame.Question.text = question;

        // Attendre la réponse du joueur
        while (interfaceGame.Answer.text == "")
        {
            // ...
        }

        // Traiter la réponse
        // ...
    }

    public interface QuestionAnswerInterface
    {
        TextMeshProUGUI Question { get; set; }
        TextMeshProUGUI Answer { get; set; }
    }


    private void Start()
    {
        // Initialiser la phrase courante
        phraseIndex = Random.Range(0, phrases.Length);
        textMesh.text = phrases[phraseIndex].ToString();

        // Démarrer le chronomètre
        StartCoroutine(StopWritingCoroutine());

    }

    private IEnumerator StopWritingCoroutine()
    {
        yield return new WaitForSeconds(stopWritingAfter);

        // Arrêter l'écriture
        textMesh.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Si le joueur appuie sur l'écran, arrêter l'écriture de la phrase
        if (textMesh.enabled)
        {
            Ghostwriter.StopWriting(15.0f);
        }
    }

    private static void StopWriting(float v)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Si le joueur déplace son doigt, continuer l'affichage de la phrase
        if (textMesh.enabled)
        {
            textMesh.enabled = true;
        }
    }

    private void Update()
    {
        // Animer l'affichage de la phrase
        textMesh.text += ".";

        // Si la phrase est terminée, passer à la phrase suivante
        if (phraseIndex < phrases.Length - 1)
        {
            phraseIndex++;
            textMesh.text = phrases[phraseIndex].ToString();
        }
    }
}