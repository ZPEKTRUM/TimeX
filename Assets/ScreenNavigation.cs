using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenNavigation : MonoBehaviour, ITouchDownHandler, ITouchUpHandler, ITouchMoveHandler
{
    private Vector2 startPosition;
    private Vector2 currentPosition;
    private float dragAmount;

    // Limit the movement of the screen to a certain zone
    public Vector2 minPosition;
    public Vector2 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = Vector2.zero;

    }

    // On touch down, save the start position
    public void OnTouchDown(Touch eventData)
    {
        startPosition = eventData.position;
    }

    // On touch up, reset the drag amount
    public void OnTouchUp(Touch eventData)
    {
        dragAmount = 0;
    }

    // On touch move, update the current position and drag amount
    public void OnTouchMove(Touch eventData)
    {
        currentPosition = eventData.position;

        // Get the touch with the most pressure
        Touch touch = Input.GetTouch(0);

        // If the touch is outside the zone of click, ignore it
        if (touch.position.x < minPosition.x || touch.position.x > maxPosition.x)
        {
            return;
        }

        // Calculate the direction of the drag
        Vector2 direction = (currentPosition - startPosition).normalized;

        // Move the camera in the direction of the drag
        float cameraTranslation = dragAmount * Time.deltaTime;
        transform.Translate(direction * cameraTranslation);

        // Check if the camera has reached the end of the screen
        if (transform.position.x <= minPosition.x)
        {
            Debug.Log("far left");
            // Reset the camera position
            transform.position = Vector2.one;
        }
        else if (transform.position.x >= maxPosition.x)
        {
            // Reset the camera position
            transform.position = Vector2.zero;
        }

        // Check if the camera has reached the middle of the screen
        if (transform.position.x <= 0.5f)
        {
            // Stop the camera from moving
            dragAmount = 0;
        }
    }

    private Transform GetTransform()
    {
        // Find the camera by its type
        Camera camera = FindObjectOfType<Camera>() as Camera;

        // Return the camera transform
        return camera.transform;
    }
}

internal interface ITouchMoveHandler
{
}

internal interface ITouchUpHandler
{
}