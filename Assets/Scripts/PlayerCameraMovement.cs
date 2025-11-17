using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    public CinemachineCamera mainCamera;
    
    void Start()
    {
        mainCamera = FindAnyObjectByType<CinemachineCamera>();
    }

    void Update()
    {
        transform.rotation = mainCamera.transform.rotation;
    }
}
