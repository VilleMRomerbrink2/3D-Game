using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    Rigidbody rB;


    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            rB.AddRelativeForce(0, 0, playerSpeed);
        }
    }
}
