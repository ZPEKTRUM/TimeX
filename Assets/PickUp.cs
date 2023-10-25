using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    #region Exposed
    [SerializeField]
    private IntVariable _MoneyCollected;

    [SerializeField] private int _score = 1;

    #endregion

    #region Unity Lifecycle

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Code to be executed when another object enters this object's trigger collider

        if (collision.CompareTag("Player"))

        {
              
           _MoneyCollected.m_value += _score;
            Destroy(gameObject);

        }


    }

}

#endregion