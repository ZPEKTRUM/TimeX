using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class ActiveObjects : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // Ajoute un serializefield pour stocker l'�tat d'activation de l'objet.
    public bool isActive = false;

    // Ajoute un unity event pour �couter les changements d'�tat d'activation.
    public UnityEvent OnActivate;

    // Active l'objet.
    public void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
        OnActivate.Invoke();
    }

    // D�sactive l'objet.
    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    // Fonction appel�e lorsque l'objet est d�marr�.
    void Start()
    {
        // Active l'objet si son �tat d'activation est d�fini sur true.
        if (isActive)
        {
            Activate();
        }

       
        {
            return;
        }
    }

    // Fonction appel�e lorsque l'utilisateur clique sur l'objet.
    public void OnPointerDown(PointerEventData eventData)
    {
        // Activer l'objet.
        Activate();
    }

    // Fonction appel�e lorsque l'utilisateur rel�che le clic sur l'objet.
    public void OnPointerUp(PointerEventData eventData)
    {
        // D�sactiver l'objet.
        Deactivate();
    }

    // Fonction appel�e lorsque l'utilisateur fait glisser l'objet.
    public void OnDrag(PointerEventData eventData)
    {
        // D�sactiver l'objet.
        Deactivate();
    }
}