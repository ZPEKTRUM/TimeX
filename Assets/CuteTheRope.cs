using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CutTheRopeScript : MonoBehaviour, IDragHandler, IPointerEnterHandler
{
    // Son ou effet � jouer lorsque la corde est coup�e
    public AudioClip soundClip;

    // Animation � jouer lorsque la corde est coup�e
    public AnimationClip animationClip;

    // Variable pour stocker le score
    public int score = 0;

    // Variable pour stocker les cordes � couper
    public GameObject[] ropes;

    private bool isCut = false;

    private void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // R�cup�re la position du pointeur
        Vector2 pointerPosition = eventData.position;

        Debug.Log("destroy");
        Destroy(gameObject);
        // Parcours les cordes
        //foreach (GameObject rope in ropes)
        //{
        //    // V�rifie si le pointeur est sur la corde
        //    if (rope.GetComponent<Collider2D>().OverlapPoint(pointerPosition))
        //    {
        //        // Coupe la corde
        //        rope.GetComponent<RopeScript>().Cut();

        //        // Arr�te le parcours
        //        break;
        //    }
        //}

        // Affiche une fen�tre de dialogue
        Debug.Log("Vous avez gagn� !");
    }

    public void Cut()
    {
        // Change l'�tat de la corde
        isCut = true;

        // Supprime l'objet de la sc�ne
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

        // G�re la fin du jeu
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

// Classe pour g�rer les cordes
public class RopeScript : MonoBehaviour
{
    public void Cut()
    {
        // Supprime l'objet de la sc�ne
        Destroy(gameObject);
    }
}