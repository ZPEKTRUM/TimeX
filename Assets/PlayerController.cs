using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float moveX = 0;
    public float moveY = 0;
    private float X;
    private float Y;

    public float speed = 5f; // Vitesse de déplacement
    internal bool HasCollectedToken;

    public static object Instance { get; internal set; }

    void Update()
    {
        // Détection des touches
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcul de la direction de déplacement
        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized;

        // Mise à jour des variables X et Y
        X = direction.x;
        Y = direction.y;

        // Mise à jour de l'animation
        animator.SetFloat("Idle", direction.magnitude == 0 ? 1f : 0f);
        animator.SetFloat("Walk", Mathf.Abs(Y));

        // Déplacement du personnage
        if (direction.magnitude > 0)
        {
            transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        }
    }
}