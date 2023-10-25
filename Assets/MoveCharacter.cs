using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class MoveCharacter : MonoBehaviour
{


    [SerializeField] InputActionReference _move;
    //[SerializeField] CharacterController _controller;
    [SerializeField] float _speed;

    [SerializeField] AudioClip _shootAudioClip;
    [SerializeField] ParticleSystem _shootParticleSystem;

    [SerializeField] Camera _cam;
    [SerializeField] InputActionReference _fireInput;

    [SerializeField] float _ammoMax;
    [SerializeField] UnityEvent _onFire;

    [Header("Debug")]
    [SerializeField] float _currentAmmo;

    private void Start()
    {
        _currentAmmo = _ammoMax;
    }

    private Vector3 _speedVector;

    private void Update()
    {

        // On calcul le point central de l'écran
        Vector2 centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);

        // On demande à la camera de nous donner un rayon qui part de la cam dans sa direction
        Ray cameraRay = _cam.ScreenPointToRay(centerScreen);


        Move();


        UpdateLook();

    }

    private void UpdateLook()
    {
    }

    private void Move()
    {
        // On récupère la direction du joystick
        Vector2 joystick = _move.action.ReadValue<Vector2>();

        // On prépare un vector3 qui prend le horizontal comme direction X.
        Vector3 direction = new Vector3(joystick.x, 0);

        /// On lui applique une vitesse
        direction *= _speed;
        //direction = _controller.transform.TransformDirection(direction);

        // On envoi au CharacterController
       // _controller.Move(direction * Time.deltaTime);

        // Tir
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Jouer l'audio
            AudioSource.PlayClipAtPoint(_shootAudioClip, transform.position);

            // Jouer l'effet de particule
            _shootParticleSystem.Play();
        }
    }
}

