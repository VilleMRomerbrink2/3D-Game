using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    float playerSpeed;
    float playerSpeedWhenInAir;

    [Header("Check For Ground")]

    public bool touchingGrass = false;

    Rigidbody rB;
    InputAction moveAction;

    Vector2 moveVector;

    void Start()
    {
        rB = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        PlayerController();

        if (touchingGrass == true)
        {
            rB.linearDamping = 10;
        }
        else
        {
            rB.linearDamping = 0;
        }
        SpeedControl();
    }

    void PlayerController()
    {
        if (moveVector.y > 0)
        {
            rB.AddRelativeForce(0, 1, playerSpeed);
        }
        else if (moveVector.y < 0)
        {
            rB.AddRelativeForce(0, 1, -playerSpeed);
        }
        if (moveVector.x > 0)
        {
            rB.AddRelativeForce(playerSpeed, 1, 0);
        }
        else if (moveVector.x < 0)
        {
            rB.AddRelativeForce(-playerSpeed, 1, 0);
        }

        if (Keyboard.current.shiftKey.IsPressed())
        {
            playerSpeed = 60;
        }
        else
        {
            playerSpeed = 25;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            touchingGrass = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            touchingGrass = false;
        }
    }

    void SpeedControl()
    {
        if (!touchingGrass && rB.linearVelocity.x > playerSpeedWhenInAir)
        {
            rB.linearVelocity = new Vector3(playerSpeedWhenInAir, rB.linearVelocity.y, rB.linearVelocity.z);
        }
        else if (!touchingGrass && rB.linearVelocity.x < -playerSpeedWhenInAir)
        {
            rB.linearVelocity = new Vector3(-playerSpeedWhenInAir, rB.linearVelocity.y, rB.linearVelocity.z);
        }
        if (!touchingGrass && rB.linearVelocity.z > playerSpeedWhenInAir)
        {
            rB.linearVelocity = new Vector3(rB.linearVelocity.x, rB.linearVelocity.y, playerSpeedWhenInAir);
        }
        else if (!touchingGrass && rB.linearVelocity.z < -playerSpeedWhenInAir)
        {
            rB.linearVelocity = new Vector3(rB.linearVelocity.x, rB.linearVelocity.y, -playerSpeedWhenInAir);
        }
    }
}