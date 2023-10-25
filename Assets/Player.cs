using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float score;

    public float pointsPersSecond_20;

    private void FixedUpdate()
    {
        score += pointsPerSecond * Time.deltaTime;
        score = timeRemaining * pointsPerSecond;
    }


    // The Rigidbody 2D component for the player.
    public Rigidbody2D rb;

    // The time at which the player was created.
    private float birthTime;

    // The duration of the player's life in seconds.
    private float lifeTime = 60f;

    // The UI TextMesh Pro component for the timer.
    public TextMeshProUGUI timer;

    // The serialize field for the time.
    public float time;
    private int pointsPerSecond;
    private int timeRemaining;

    private void Start()
    {
        birthTime = Time.time;
    }

    // The update function.
    void Update()
    {
        // If the player is still alive, move it based on the input.
        float t = Time.time - birthTime;
        if (t < lifeTime)
        {
            rb.AddForce(transform.right * Input.GetAxisRaw("Horizontal"));
        }
        else
        {
            // If the player is dead, destroy it.
            Destroy(gameObject);
        }

        // Update the timer.
        if (timer is null) return;
        timer.text = ((int)t).ToString();
    }
}