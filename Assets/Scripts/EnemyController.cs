using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;

    bool seesPlayer = false;

    [SerializeField] GameObject player;
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
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
            Destroy(gameObject, lifeTime);
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
