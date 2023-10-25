using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CutTheRopeScript : MonoBehaviour, IDragHandler, IPointerEnterHandler
{
    // Son ou effet à jouer lorsque la corde est coupée
    public AudioClip soundClip;

    // Animation à jouer lorsque la corde est coupée
    public AnimationClip animationClip;

    // Variable pour stocker le score
    public int score = 0;

    // Variable pour stocker les cordes à couper
    public GameObject[] ropes;

    private bool isCut = false;

    private void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Récupère la position du pointeur
        Vector2 pointerPosition = eventData.position;

        Debug.Log("destroy");
        Destroy(gameObject);
        // Parcours les cordes
        //foreach (GameObject rope in ropes)
        //{
        //    // Vérifie si le pointeur est sur la corde
        //    if (rope.GetComponent<Collider2D>().OverlapPoint(pointerPosition))
        //    {
        //        // Coupe la corde
        //        rope.GetComponent<RopeScript>().Cut();

        //        // Arrête le parcours
        //        break;
        //    }
        //}

        // Affiche une fenêtre de dialogue
        Debug.Log("Vous avez gagné !");
    }

    public void Cut()
    {
        // Change l'état de la corde
        isCut = true;

        // Supprime l'objet de la scène
        Destroy(gameObject);

        // Joue le son
        if (soundClip != null)
        {
            AudioSource.PlayClipAtPoint(soundClip, transform.position);
        }

        // Joue l'animation
        if (animationClip != null)
        {
            Animator animator = GetComponent<Animator>();
            animator.Play("Cut");
        }

        // Augmente le score
        score++;

        // Gère la fin du jeu
        if (score == ropes.Length)
        {
            // Active le bouton pour recommencer
            //GameObject.Find("Restart").GetComponent<Button>().interactable = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

}

// Classe pour gérer les cordes
public class RopeScript : MonoBehaviour
{
    public void Cut()
    {
        // Supprime l'objet de la scène
        Destroy(gameObject);
    }
}