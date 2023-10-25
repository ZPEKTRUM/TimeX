using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class ActiveObjects : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // Ajoute un serializefield pour stocker l'état d'activation de l'objet.
    public bool isActive = false;

    // Ajoute un unity event pour écouter les changements d'état d'activation.
    public UnityEvent OnActivate;

    // Active l'objet.
    public void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
        OnActivate.Invoke();
    }

    // Désactive l'objet.
    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    // Fonction appelée lorsque l'objet est démarré.
    void Start()
    {
        // Active l'objet si son état d'activation est défini sur true.
        if (isActive)
        {
            Activate();
        }

       
        {
            return;
        }
    }

    // Fonction appelée lorsque l'utilisateur clique sur l'objet.
    public void OnPointerDown(PointerEventData eventData)
    {
        // Activer l'objet.
        Activate();
    }

    // Fonction appelée lorsque l'utilisateur relâche le clic sur l'objet.
    public void OnPointerUp(PointerEventData eventData)
    {
        // Désactiver l'objet.
        Deactivate();
    }

    // Fonction appelée lorsque l'utilisateur fait glisser l'objet.
    public void OnDrag(PointerEventData eventData)
    {
        // Désactiver l'objet.
        Deactivate();
    }
}