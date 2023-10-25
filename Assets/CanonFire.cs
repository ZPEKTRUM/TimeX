using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{

    public float speed = 100;
    public Transform target;

    public bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called every frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }

        if (isShooting)
        {
            // V�rifie si la cible est nulle
            if (target != null)
            {
                // D�place le projectile vers la cible
                Vector3 direction = target.position - transform.position;

                // Convertit le vecteur Vector2 en vecteur Vector3
                direction.z = 0;

                // Ajoute le vecteur Vector3 au vecteur Vector3
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    // Fonction appel�e lorsque le joueur appuie sur l'�cran
    void OnPointerDown()
    {
        isShooting = true;
    }

    // Fonction appel�e lorsque le joueur rel�che l'�cran
    void OnPointerUp()
    {
        isShooting = false;
    }

    IEnumerator DestroyEnemy(Collider2D collider)
    {
        // D�sactive le collider2D
        collider.enabled = false;

        // Attend une seconde
        yield return new WaitForSeconds(1);

        // D�truit le GameObject
        Destroy(collider.gameObject);
    }
}


