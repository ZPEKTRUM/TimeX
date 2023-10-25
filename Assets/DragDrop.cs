using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandr, IEndDragHandler, IDropHandler
{

   [SerializeField]  private Canvas canvas; 

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup; 

    private void Awake()

    {
   
        rectTransform  = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    
    }

    public void OnBeginDrag(PointerEventData eventData) //End drag 
    {
        Debug.Log("OnBegindrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
       Debug.Log("OnDrag");
       rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData) //End drag 
    {
        Debug.Log("OnEndrag");
        canvasGroup.alpha = .1f;
        canvasGroup.blocksRaycasts = true; 

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDow");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
