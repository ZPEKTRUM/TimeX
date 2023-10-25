using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static TokenInstance;

public class TokenInstance : MonoBehaviour, IPointerDownHandler, IDragHandler, ITouchable
{

    public PlayerController player;

    void OnTouchDown(Touch touch)
    {
        //Update UI
        ManageScore.instance.AddPoint();

        //Check if player already collected token
        if (player.HasCollectedToken)
        {
            return;
        }

        //Set flag to indicate that player has collected token
        player.HasCollectedToken = true;

        //Remove token
        RemoveToken();
    }

    void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    void RemoveToken()
    {
        //Remove token from scene
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        //If the player enters the trigger area, collect the token
        if (other.gameObject == player.gameObject)
        {
            OnTouchDown(null);
        }
    }

    void OnPlayerTagEnter(Collider other)
    {
        //If the player enters the trigger area with the Player tag, collect the token
        if (other.gameObject.tag == "Player")
        {
            OnTouchDown(null);
        }
    }

    private void OnTouchDown(object value)
    {
        throw new NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    internal interface ITouchable
    {
    }
}