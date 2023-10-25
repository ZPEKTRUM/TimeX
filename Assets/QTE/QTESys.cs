using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class QTESys : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public TextMeshProUGUI DisplayBox;
    public TextMeshProUGUI PassBox;
    public int QTEGen;
    public int CorrectKey;
    private int WaitingForKey;
    public int CountingDown;

    private void Update()
    {
        // G�n�rez un nouveau QTE si l'utilisateur touche l'�cran
        if (Input.touchCount > 0)
        {
            QTEGen = UnityEngine.Random.Range(1, 4);
        }

        CountingDown = 1;

        // Ligne 36 :
        StartCoroutine(CountDown());

        // Ligne 38 :
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            // V�rifiez si la bonne touche a �t� touch�e
            if (Input.GetTouch(0).fingerId == CorrectKey)
            {
                // La bonne touche a �t� touch�e
                // Ne rien faire, la v�rification a d�j� �t� faite dans Update()
            }
            else
            {
                // La mauvaise touche a �t� touch�e
                // Ne rien faire, la v�rification a d�j� �t� faite dans Update()
            }

            // R�initialiser la variable CorrectKey et les textes du HUD
            CorrectKey = 0;
            PassBox.text = "";
            DisplayBox.text = "";
        }
    }


    private IEnumerator CountDown()
    {
        Debug.Log("CountDown() coroutine started");
        yield return new WaitForSeconds(3.5f);

        if (CountingDown == 1)
        {
            Debug.Log("CountDown() coroutine timed out");
            QTEGen = 4;

            CountingDown = 2;
            PassBox.text = "FAIL!!!";
            yield return new WaitForSeconds(1.5f);

            CorrectKey = 0;

            PassBox.text = "";
            DisplayBox.text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        // Not implemented
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Not implemented
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Not implemented
    }
}