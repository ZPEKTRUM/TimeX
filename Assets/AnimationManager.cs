using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    Animator animator; // D�finition de l' animateur heure Regenerate

    bool isTouching; // Indique si l'utilisateur est en train de toucher l'�cran
    bool isTurning; // Indique si le plateau de jeu est en train de tourner

    bool isMouseClicked; // Indique si l'utilisateur a cliqu� sur l'�cran

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); //Regenerate composant
        isTouching = false;
        isTurning = false;
        isMouseClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        // V�rifie si l'utilisateur est en train de toucher l'�cran
        isTouching = Input.touchCount > 0;
        isMouseClicked = Input.GetMouseButtonDown(0);

        GetTouch();
    }

    public void GetTouch()
    {
        // Si l'utilisateur est en train de toucher l'�cran et que le plateau de jeu n'est pas en train de tourner, alors tourne le plateau de jeu
        if (isTouching && !isTurning)
        {
            TurnBoard();
        }

        // Si l'utilisateur a cliqu� sur l'�cran et que le plateau de jeu n'est pas en train de tourner, alors tourne le plateau de jeu
        if (isMouseClicked && !isTurning)
        {
            TurnBoard();
        }
    }


    private void TurnBoard()
    {
if(!isTurning) {
            animator.SetBool("1turnBoard", true);
            isTurning = true;
        }
        else 
        {
            animator.SetBool("1turnBoard", true);
            isTurning = false;
        }


    }




    public void OnPointerUp(PointerEventData eventData)
    {
        // Appel� lorsque l'utilisateur rel�che son doigt de l'�cran
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Appel� lorsque l'utilisateur appuie sur l'�cran
        isMouseClicked = Input.GetMouseButtonDown(0);

        Debug.Log("OnMouse");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Appel� lorsque l'utilisateur fait glisser son doigt sur l'�cran
    }
}