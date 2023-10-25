using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float moveX = 0;
    public float moveY = 0;
    private float X;
    private float Y;

    public float speed = 5f; // Vitesse de d�placement
    internal bool HasCollectedToken;

    public static object Instance { get; internal set; }

    void Update()
    {
        // D�tection des touches
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcul de la direction de d�placement
        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized;

        // Mise � jour des variables X et Y
        X = direction.x;
        Y = direction.y;

        // Mise � jour de l'animation
        animator.SetFloat("Idle", direction.magnitude == 0 ? 1f : 0f);
        animator.SetFloat("Walk", Mathf.Abs(Y));

        // D�placement du personnage
        if (direction.magnitude > 0)
        {
            transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        }
    }
}