using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] new Rigidbody2D rigidbody2D;

    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    private int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        VelocityHash = Animator.StringToHash("Velocity");
        animator.Play("Walk");
    }

    // Update is called once per frame
    void Update()
    {
        // Get key input from player
        bool forwardPressed = Input.GetKey("a");
        bool runPressed = Input.GetKey("r");

        // Move the GameObject based on key input
        rigidbody2D.AddForce(new Vector2(0.0f, forwardPressed ? (runPressed ? 2.0f * acceleration : acceleration) : 0.0f));

        // Update the velocity variable
        velocity = rigidbody2D.velocity.magnitude;

        // Set the Velocity animation parameter
        animator.SetFloat(VelocityHash, velocity);

        // Play the appropriate animation based on velocity
        if (velocity > 0.0f)
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");

            // Check if the player is pressing the walk button
    if (Input.GetKeyDown("space"))
    {
        // Call the Walk() function
        Walk();
        }


    }
}

    private void Walk()
    {
        throw new NotImplementedException();
    }
}
