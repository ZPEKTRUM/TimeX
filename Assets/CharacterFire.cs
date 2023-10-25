using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class CharacterFire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // Param�tres de base

    [SerializeField] Camera _cam;
    [SerializeField] InputActionReference _fireInput; // L' input pour d�clencher le tir

    [SerializeField] float _ammoMax; // Munitions maximales
    [SerializeField] UnityEvent _onFire; // �v�nement d�clench� � chaque tir

    // Informations de d�bogage

    [Header("Debug")]
    [SerializeField] float _currentAmmo; // Munitions actuelles
    internal int ammo;

    private void Start()
    {
        _currentAmmo = _ammoMax;
    }

    private void Update()
    {
        // On calcule le point central de l'�cran
        Vector2 centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);

        // On demande � la camera de nous donner un rayon qui part de la cam dans sa direction
        Ray cameraRay = _cam.ScreenPointToRay(centerScreen);


        // On va pouvoir lancer un raycast
        Debug.DrawRay(cameraRay.origin, cameraRay.direction, Color.red);
        if (_fireInput.action.WasPressedThisFrame())
        {
            if (_currentAmmo <= 0) return;
            _currentAmmo--;
            _onFire.Invoke();

            //if (Physics.Raycast(cameraRay, out RaycastHit hit, Mathf.Infinity))
            //{
            //    // Si le joueur a apuy� sur le bouton d'interaction
            //    Debug.Log($"touch� {hit.GetComponent<Collider>().name}!");
            //    if (hit.GetComponent<Collider>().TryGetComponent(out Health usable))
            //    {
            //        usable.TakeDamage(10);
            //    }
            //}
        }
    }

    public void Refill()
    {
        _currentAmmo = _ammoMax;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // throw new NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // throw new NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // throw new NotImplementedException();
    }

    private class Health
    {
        internal void TakeDamage(int v)
        {
            //throw new NotImplementedException();
        }


    }
}