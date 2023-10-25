using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    public int Health;
    public float PlayerVelocity;
    public float Boundary;
    public int PlayerPoints;
    public GameObject Player;
    public Canvas MainMenu;
    public Canvas Pauses;
    public float Movement
    {
        get { return MovesLeft ? -1f : MovesRight ? 1f : 0f; }
    }

    public bool MovesLeft { get; set; } = false;
    public bool MovesRight { get; set; } = false;

    private Vector3 playerPosition;

    // Start is called before the first frame update

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Die();
        }

    }
    public void Die()
    {
        if (PlayerPrefs.GetInt("Score") < PlayerPoints)
        {
            PlayerPrefs.SetInt("Score", PlayerPoints);
        }
        //SaveScoreScript.AddScore(PlayerPoints);

        Time.timeScale = 0;
        MainMenu.gameObject.SetActive(true);

    }

    void Start()
    {
        PlayerPoints = 0;
        playerPosition = gameObject.transform.position;
    }

    public void AddPoints(int points)
    {
        PlayerPoints += points;
    }

    // Update is called once per frame

    void Update()
    {
        if (Pauses == true)
        {
            Debug.Log("Time-test");
            Time.timeScale = 0;
        }

        // Detect touch input
        Touch[] touches = Input.touches;

        // If there is a touch input
        if (touches.Length > 0)
        {
            // Get the position of the first touch
            Touch touch = touches[0];

            // If the touch is in the left half of the screen
            if (touch.position.x < Screen.width / 2)
            {
                MovesLeft = true;
            }

            // If the touch is in the right half of the screen
            else if (touch.position.x > Screen.width / 2)
            {
                MovesRight = true;
            }
        }

        // If the player is not moving left or right
        else
        {
            MovesLeft = false;
            MovesRight = false;
        }

        // Move the player
        float newX = playerPosition.x + Movement * PlayerVelocity;

        newX = Mathf.Clamp(newX, -Boundary, Boundary);

        transform.position = playerPosition = new Vector3(newX, playerPosition.y, playerPosition.z);

    }

}