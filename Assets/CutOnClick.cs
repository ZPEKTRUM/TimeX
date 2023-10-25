using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CutOnClick : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] InputActionReference _mouse;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
