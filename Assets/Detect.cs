using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detect : MonoBehaviour
{
    [SerializeField] UnityEvent _onDetected;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detected");
        _onDetected.Invoke();
    }
}