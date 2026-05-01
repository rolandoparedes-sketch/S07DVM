using UnityEngine;

public class Turret : MonoBehaviour
{
    public float detectionRange = 10f;   
    public string enemyTag = "Enemy";
    public float rotationSpeed = 5f;

    void Update()
    {
        GameObject target = FindTarget(); 

        if (target != null)
        {
            RotateToTarget(target.transform); // Rotar hacia el enemigo
        }
    }

    GameObject FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance <= detectionRange)
            {
                return enemy; // devuelve el primero que esté en rango
            }
        }

        return null;
    }

    void RotateToTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0f;

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }
    void OnCollisionEnter(Collision collision)
    {

    }
}