using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareSequence : MonoBehaviour
{

    [SerializeField] int framesUntilDead;
    int timeSinceGrabbed;


    void FixedUpdate()
    {
        timeSinceGrabbed++;

        if (timeSinceGrabbed >= framesUntilDead)
        {
            SceneManager.LoadScene(0);
        }
    }
}
