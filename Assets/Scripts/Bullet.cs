using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        rb.linearVelocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
