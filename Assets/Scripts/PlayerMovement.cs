using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    [SerializeField] float playerSpeed;

    [Header("Check For Ground")]

    public bool touchingGrass;

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
    }

    void PlayerController()
    {
        if (moveVector.y > 0 && touchingGrass)
        {
            rB.AddRelativeForce(0, 0, playerSpeed);
        }
        else if (moveVector.y < 0 && touchingGrass)
        {
            rB.AddRelativeForce(0, 0, -playerSpeed);
        }
        if (moveVector.x > 0 && touchingGrass)
        {
            rB.AddRelativeForce(playerSpeed, 0, 0);
        }
        else if (moveVector.x < 0 && touchingGrass)
        {
            rB.AddRelativeForce(-playerSpeed, 0, 0);
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
}
