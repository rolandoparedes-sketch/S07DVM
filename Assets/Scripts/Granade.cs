using UnityEngine;
using UnityEngine.Events;

public class Granade : MonoBehaviour
{
    public float timer;
    public float radius;
    public LayerMask mask;
    public UnityEvent OnExplotion;
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

        foreach (var cool in colls)
        {
            Debug.Log(" Mueran todos");
        }
        OnExplotion?.Invoke();

        Destroy(gameObject);
    }
}
