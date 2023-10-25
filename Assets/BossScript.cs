using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int Health;
    public int points;
    public float EnemyVelocity;

    private Vector2 target;
    private Vector2 enemyPosition;
    public PlayerScripts Player { get; set; }

    public enum State
    {
        Left,
        Right
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        if (Health == 0)
        {
            Player.AddPoints(points);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public State enemyState = State.Right;

    void Start()
    {
        enemyPosition = gameObject.transform.position;
        target = enemyPosition + GetNextTarget(enemyState);
    }

    void Update()
    {
        // Handle touch screen input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.position.x < Screen.width / 2)
            {
                SwitchState(State.Left);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                SwitchState(State.Right);
            }
        }

        // Move towards target position
        transform.position = Vector2.MoveTowards(transform.position, target, EnemyVelocity * Time.timeScale);

        // Switch state if target position is reached
        
        {
            SwitchState(enemyState);
        }
    }

    private Vector2 GetNextTarget(State state)
    {
        switch (state)
        {
            case State.Left: return Vector2.left * 6;
            case State.Right: return Vector2.right * 6;
            default: return Vector2.zero;
        }
    }

    private void SwitchState(State state)
    {
        switch (state)
        {
            case State.Left:
                enemyState = State.Right;
                break;
            case State.Right:
                enemyState = State.Left;
                break;
        }
       
    }
}