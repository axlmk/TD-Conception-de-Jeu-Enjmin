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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < collidingEnemies.Count; i++)
            {
                Collider enem = collidingEnemies[i];
                Debug.Log("dealing damage to " + " " + enem.gameObject.name);
                if (!enem.gameObject.GetComponent<AiEnemy>().TakeDamage())
                {
                    collidingEnemies.RemoveAt(i);
                    Debug.Log("removing enemy after kill" + " " + enem.gameObject.name);
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
            Debug.Log("adding enemy " + " " + other.gameObject.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            collidingEnemies.Remove(other);
            Debug.Log("removing enemy " + " " + other.gameObject.name);
        }
    }
}
