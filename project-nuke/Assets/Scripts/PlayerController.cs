using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public InputActions playerInputActions;

    public int moveSpeed;

    private InputAction movement;

    // Start is called before the first frame update
    void Awake()
    {
        playerInputActions = new InputActions();
        movement = playerInputActions.Player.Movement;
        movement.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerRigidBody.velocity = movement.ReadValue<Vector2>() * moveSpeed;
    }
}
