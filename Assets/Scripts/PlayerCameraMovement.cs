using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    public CinemachineCamera mainCamera;

    float cameraRotateX;
    
    void Start()
    {
        mainCamera = FindAnyObjectByType<CinemachineCamera>();
    }

    void Update()
    {
        transform.rotation = mainCamera.transform.rotation;
        
        if (transform.rotation.x != 0)
        {
            cameraRotateX = 0 - transform.rotation.x;

            transform.Rotate(cameraRotateX, 0, 0);
        }
    }
}
