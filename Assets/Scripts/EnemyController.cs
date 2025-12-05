using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;

    bool seesPlayer = false;

    [SerializeField] GameObject player;
    [SerializeField] GameObject thisObject;
    void Start()
    {

    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        
        if(seesPlayer)
        {
            thisObject.transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
            thisObject.transform.LookAt(playerPosition);
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            seesPlayer = true;
        }
        
    }
}
