using UnityEngine;
using UnityEngine.Events;

public class Granade : MonoBehaviour
{
    public float timer;
    public float radius;
    public LayerMask mask;
    public UnityEvent OnExplotion;
    public GameObject explosionEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(OnExplode), timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnExplode()
    {
        
        Collider[] colls = Physics.OverlapSphere(transform.position, radius, mask);

        foreach (var coll in colls)
        {
            if (coll.CompareTag("Enemy"))
            {
                Destroy(coll.gameObject);
            }
        }
        GameObject fx = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(fx, 1f);
        OnExplotion?.Invoke();

        Destroy(gameObject);
    }
}
