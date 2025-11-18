using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;

    Vector2 moveVector;

    Rigidbody rB;
    InputAction moveAction;


    void Start()
    {
        rB = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        PlayerController();
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
        else if (moveVector.x > 0)
        {
            rB.AddRelativeForce(playerSpeed, 0, 0);
        }
        else if (moveVector.x < 0)
        {
            rB.AddRelativeForce(-playerSpeed, 0, 0);
        }
    }
}
