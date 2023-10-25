using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragXCube : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        var pos = Camera.main.ScreenToWorldPoint(eventData.position);
        pos.z = 0;

        transform.position = pos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
    }
}