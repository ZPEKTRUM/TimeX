using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject target;
    public Animator animator;

    void Update()
    {
        // Raycast vers le target
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 100);

        // Si le raycast a touché le target
        if (hit.collider != null && hit.collider.gameObject == target)
        {
            // Si le target est en mouvement
            if (target.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {
                // Si le target sort de la zone du player
                if (hit.distance > 50)
                {
                    // Revenir à la scène précédente
                    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                    return;
                }
            }

            // Modifier l'animation du player
            animator.SetTrigger("Trigger");

            // Invoker une fonction pour charger la scène suivante
            Invoke("LoadNextScene", 0.5f);
        }
    }

    // Fonction pour charger la scène suivante
    void LoadNextScene()
    {
        // Charger la scène suivante
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene2");
    }
}