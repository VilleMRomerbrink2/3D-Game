using Unity.Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    CinemachineCamera cam;

    void Start()
    {
        cam = FindFirstObjectByType<CinemachineCamera>();
    }

    void FixedUpdate()
    {
        transform.rotation = cam.transform.rotation;
    }
}
