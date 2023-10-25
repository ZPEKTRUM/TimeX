using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] Animator _animator;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        // Play the hurt animation
        _animator.SetBool("RedQidle", true);

        // If the enemy has no health, destroy it
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}