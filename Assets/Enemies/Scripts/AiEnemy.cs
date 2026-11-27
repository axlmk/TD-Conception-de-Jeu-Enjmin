using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiEnemy : MonoBehaviour
{
    public GameObject player;
    public uint DistanceFromPlayer = 10;

    private NavMeshAgent enemy;
    public uint health = 5;
    private ParticleSystem blood;
    private AudioSource[] sounds;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        blood = GetComponent<ParticleSystem>();
        sounds = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < DistanceFromPlayer)
        {

            enemy.SetDestination(player.transform.position);
        }

        if (health <= 0)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            if (!(sounds[1].isPlaying))
            {
                Destroy(gameObject);
            }
        }
    }

    public bool TakeDamage()
    {
        health -= 1;
        blood.Play();
        if (health > 0)
        {
            sounds[0].Play();
        }
        else
        {
            sounds[1].Play();
        }
        return health > 0;
    }
}