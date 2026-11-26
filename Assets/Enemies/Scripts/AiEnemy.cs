using UnityEngine;
using UnityEngine.AI;

public class AiEnemy : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent enemy;
    private uint health;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        health = 5;
    }

    void Update()
    {
        enemy.SetDestination(player.transform.position);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool TakeDamage()
    {
        health -= 1;
        return health > 0;
    }
}