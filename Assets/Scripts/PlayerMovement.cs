using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            myRigidbody.AddForce(, 100);
        }
    }
}
