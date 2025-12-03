using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] GameObject mCamera;

    Quaternion camRotation; 

    void Update()
    {
        Quaternion camRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mCamera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = camRotation;
    }

    
}
