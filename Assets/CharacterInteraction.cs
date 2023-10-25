using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    [SerializeField] Camera _cam; // On demande la cam�ra
    [SerializeField] InputActionReference _interaction; // L' input pour savoir quand d�clencher l' action.  

    public void OnDrag(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }

    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // On calcul le point central de l'�cran
        Vector2 centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);

        // On demande � la camera de nous donner un rayon qui part de la cam dans sa direction
        Ray cameraRay = _cam.ScreenPointToRay(centerScreen);

        // On va pouvoir lancer un raycast
        Debug.DrawRay(cameraRay.origin, cameraRay.direction, Color.red);
        if (Physics.Raycast(cameraRay, out RaycastHit hit, 2f))
        {
            //Debug.Log($"touch� {hit.GetComponent<Collider>().name}!");
            //hit.GetComponent<Collider>().GetComponent<MeshRenderer>()?.sharedMaterial.SetFloat("_OutlineEnabled", 1);

            // Si le joueur a appuy� sur le bouton d'interaction
            if (_interaction.action.WasPressedThisFrame())
            {
                //if (hit.GetComponent<Collider>().TryGetComponent(out IInteractable usable))
                //{
                //    usable.Use();
                //}
            }
        }
    }

}