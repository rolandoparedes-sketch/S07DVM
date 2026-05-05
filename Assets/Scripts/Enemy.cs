using System.IO;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float distanceToDamage = 1.5f;
    public float Speed = 5f;
    public float ActiveRadius = 10f;


    private NavMeshAgent agent;

    private float lastHitTime;
    public float damageCooldown = 1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null || agent == null) return;


        if (agent.isOnNavMesh)
        {
            agent.SetDestination(player.position);
        }


        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= distanceToDamage && Time.time > lastHitTime + damageCooldown)
        {
            lastHitTime = Time.time;

            ThirdPersonController playerScript = player.GetComponent<ThirdPersonController>();

            if (playerScript != null)
            {
                Vector3 hitDir = (player.position - transform.position).normalized;

            }
                  
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
       if(other.CompareTag("Player"))
        {
            CinemachineImpulseSource impulse = other.GetComponent<CinemachineImpulseSource>();
            

            if (impulse != null)
            {
                impulse.GenerateImpulse();
            }
            Destroy(gameObject);
        }
    }


}
