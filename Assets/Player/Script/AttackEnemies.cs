using System.Collections.Generic;
using UnityEngine;

public class AttackEnemies : MonoBehaviour
{
    public uint health = 5;
    private List<Collider> collidingEnemies;

    void Start()
    {
        collidingEnemies = new List<Collider>();
    }

    void Hurt()
    {
        health -= 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < collidingEnemies.Count; i++)
            {
                Collider enem = collidingEnemies[i];
                if (!enem.gameObject.GetComponent<AiEnemy>().TakeDamage())
                {
                    collidingEnemies.RemoveAt(i);
                    continue;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            collidingEnemies.Add(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            collidingEnemies.Remove(other);
        }
    }
}
