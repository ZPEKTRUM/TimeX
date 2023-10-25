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

        // Définissez la vitesse du projectile.
        rb.velocity = transform.position * speed * direction;

        // Démarrez le chronomètre de vie du projectile.
        StartCoroutine(LifeTimeCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Vérifiez si le projectile a frappé un ennemi.
        if (hitInfo.transform.CompareTag("Enemy"))
        {
            // Obtenez l'ennemi qui a été touché.
            enemy = hitInfo.GetComponent<Enemy>();

            // Infligez des dégâts à l'ennemi.
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Détruisez le projectile et l'explosion.
            Destroy(gameObject);
            Destroy(explosion);
        }

        // Affichez le nom de l'objet qui a été touché.
        Debug.Log(hitInfo.name);
    }

    IEnumerator LifeTimeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(lifeTime);

            // Détruisez le projectile si sa durée de vie est écoulée.
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