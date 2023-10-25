using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ammo : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private ParticleSystem particleEffect;

    [SerializeField]
    private AudioClip shootSound;
    private CharacterFire _characterFire;

    [SerializeField]
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other) //collision
    {
        if (other.GetComponent<CharacterFire>()) // Composant si call refil
        {
            _characterFire = other.GetComponent<CharacterFire>();
            _characterFire.Refill();
        }
    }

    private void OnDestroy()
    {
        // Destroy the characterFire object if it exists
        if (_characterFire)
        {
            Destroy(_characterFire);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            if (eventData.pointerId == Input.GetTouch(0).fingerId)
            {
                // Play the shoot sound and create the particle effect
                audioSource.PlayOneShot(shootSound);
                particleEffect.Play();
            }
        }
    }

    // Nouvelle méthode pour redistribuer des munitions
    public void RedistributeAmmo(CharacterFire characterFire, int amount)
    {
        // Vérifiez si le script CharacterFire existe
        if (characterFire)
        {
            // Redistribuez les munitions
            characterFire.ammo += amount;

        }

    }
    public class Item : MonoBehaviour
    {
        public Ammo ammo;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterFire>())
            {
                // Redistribuez les munitions au joueur
                ammo.RedistributeAmmo(other.GetComponent<CharacterFire>(), 10);
            }
        }
    }

}
