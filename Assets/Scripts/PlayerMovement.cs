using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    [SerializeField] float playerSpeed;

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
        if (touchingGrass == false && rB.linearVelocity.x > playerSpeed)
        {
            rB.linearVelocity = new Vector3(playerSpeed, rB.linearVelocity.y, rB.linearVelocity.x);
        }
        else if (touchingGrass == false && rB.linearVelocity.x < -playerSpeed)
        {
            rB.linearVelocity = new Vector3(-playerSpeed, rB.linearVelocity.y, rB.linearVelocity.x);
        }

        if (touchingGrass == false && rB.linearVelocity.z > playerSpeed)
        {
            rB.linearVelocity = new Vector3(rB.linearVelocity.x, rB.linearVelocity.y, playerSpeed);
        }
        else if (touchingGrass == false && rB.linearVelocity.z < -playerSpeed)
        {
            rB.linearVelocity = new Vector3(rB.linearVelocity.x, rB.linearVelocity.y, -playerSpeed);
        }
    }
}
