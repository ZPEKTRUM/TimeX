using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class DamageOnTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] int _damageAmount;
    [SerializeField] Animator _animator;
    [SerializeField] float _destroyDelay = 0.5f;
    [SerializeField] int _destroyRate = 10;

    private RaycastHit2D _hit;
    private float _raycastDistance = 10f;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Create a raycast from the player's position
        _hit = Physics2D.Raycast(transform.position, transform.forward, _raycastDistance);

        // Check if the raycast hit an enemy
        if (_hit.collider is Collider2D collider2D)
        {
            // Damage the enemy
            //collider2D.TakeDamage(_damageAmount);

            // Start a coroutine to destroy the enemy after a delay
            StartCoroutine(DestroyEnemy(collider2D, _destroyDelay));

            // Stop the animation
            _animator.StopPlayback();
        }
        else
        {
            // Continue playing the animation
            _animator.Play("RedQ3");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Stop playing the animation
        _animator.StopPlayback();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Continue playing the animation
        _animator.Play("RedQ3");
    }

    private IEnumerator DestroyEnemy(Collider2D collider2D, float delay)
    {
        // Wait for the delay
        yield return new WaitForSeconds(delay);

        // Check if the destroy rate is greater than 10
        if (_destroyRate >= 10)
        {
            // Destroy the enemy
            Destroy(collider2D.gameObject);
        }
    }
}