using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlay : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] InputActionReference _move;

    [SerializeField] float _speed;

    public static GamePlay Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("OMG");
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = _move.action.ReadValue<Vector2>();

        //transform.Translate(direction);

        _rb.velocity = direction * _speed;

    }
}


