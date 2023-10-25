using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraMain : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    Animator animator; // Définition de l' animateur heure Regenerate
    private bool isTouching;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); //Regenerate composant
    }

    private void Update()
    {
        // Only set the animator's "index" parameter if the player is touching the screen
        if (isTouching)
        {
            animator.SetInteger("index", 0);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isTouching)
        {
            animator.SetInteger("index", 1);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isTouching)
        {
            animator.SetInteger("index", 2);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Do nothing
    }
}


public class CameraController : MonoBehaviour
{
    private VJHandler joystick;

    void Start()
    {
        joystick = GetComponent<VJHandler>();
    }

    void Update()
    {
        // Obtenir la direction du joystick virtuel
        Vector3 direction = joystick.InputDirection;

        // Déplacer la caméra dans la direction obtenue
        transform.Translate(direction * Time.deltaTime);
    }
}