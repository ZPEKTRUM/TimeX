using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DebugTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnEnable()
    {
        // Initialise la position du toucher à (0, 0)
        touchPosition = Vector2.zero;
    }

    private void OnPointerDown(PointerEventData eventData)
    {
        // Met à jour la position du toucher
        touchPosition = eventData.position;

        // Affiche la position du toucher dans la console
        Debug.Log("Touch position: " + touchPosition);
    }

    private void OnPointerUp(PointerEventData eventData)
    {
        // Met à jour la position du toucher à (0, 0)
        touchPosition = Vector2.zero;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    private Vector2 touchPosition;

    void Update()
    {
        // Vérifie si la liste Input.touches contient des éléments
        if (Input.touches.Length > 0)
        {
            // Met à jour la position du toucher
            touchPosition = Input.touches[0].position;

            // Affiche la position du toucher dans la console
            Debug.Log("Touch position: " + touchPosition);
        }
    }
}