using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float Explosion_Radius;
    [SerializeField] float Explosion_Force;
    [SerializeField] int damage;
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemies>();
        enemy.Hurt(damage);
        Explode();
        Destroy(gameObject);
    }


    public void Explode()
    {
        Collider[] trigerCollider = Physics.OverlapSphere(transform.position, Explosion_Radius);

        for (int i = 0; i < trigerCollider.Length; i++)
        {
            Rigidbody rb = trigerCollider[i].attachedRigidbody;
            if (rb)
            {
                rb.AddExplosionForce(Explosion_Force,transform.position, Explosion_Radius);
            }
        }
    }
    
        
    
}
