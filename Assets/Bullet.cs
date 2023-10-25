using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private Enemy enemy;
    public int damage = 40;

    public string Tag = "Bullet";
    public float lifeTime = 5f;
    public GameObject explosion;

    void Start()
    {
        // Obtenez la direction du projectile.
        Vector2 direction = transform.forward;

        // D�finissez la vitesse du projectile.
        rb.velocity = transform.position * speed * direction;

        // D�marrez le chronom�tre de vie du projectile.
        StartCoroutine(LifeTimeCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // V�rifiez si le projectile a frapp� un ennemi.
        if (hitInfo.transform.CompareTag("Enemy"))
        {
            // Obtenez l'ennemi qui a �t� touch�.
            enemy = hitInfo.GetComponent<Enemy>();

            // Infligez des d�g�ts � l'ennemi.
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // D�truisez le projectile et l'explosion.
            Destroy(gameObject);
            Destroy(explosion);
        }

        // Affichez le nom de l'objet qui a �t� touch�.
        Debug.Log(hitInfo.name);
    }

    IEnumerator LifeTimeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(lifeTime);

            // D�truisez le projectile si sa dur�e de vie est �coul�e.
            if (Time.time > lifeTime)
            {
                Destroy(gameObject);
            }
        }
    }
}

internal class Enemy
{
    internal void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}