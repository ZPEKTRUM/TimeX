using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDistance : MonoBehaviour
{

    [SerializeField] Animator _animator;
    bool _candyDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;
        if (collision.attachedRigidbody.gameObject.CompareTag("Candy"))
        {
            _candyDetected = true;
            _animator.SetBool("Candy", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;
        if (collision.attachedRigidbody.gameObject.CompareTag("Candy"))
        {
            _candyDetected = false;
            _animator.SetBool("Candy", false);
        }
    }

}