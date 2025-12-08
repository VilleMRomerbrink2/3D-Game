using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    [SerializeField] float playerSpeed;
    [SerializeField] float playerSpeedWhenInAir;

    [Header("Check For Ground")]

    public bool touchingGrass = false;
    public LayerMask whatIsGround;
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
        GroundCheck();
    }

    void PlayerController()
    {
        if (moveVector.y > 0)
        {
            rB.AddRelativeForce(0, 0, playerSpeed);
        }
        else if (moveVector.y < 0)
        {
            rB.AddRelativeForce(0, 0, -playerSpeed);
        }
        if (moveVector.x > 0)
        {
            rB.AddRelativeForce(playerSpeed, 0, 0);
        }
        else if (moveVector.x < 0)
        {
            rB.AddRelativeForce(-playerSpeed, 0, 0);
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

    void GroundCheck()
    {

        touchingGrass = Physics.Raycast(transform.position, Vector3.down, 1.5f, whatIsGround);

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