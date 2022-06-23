using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    [SerializeField] int Damage = 4;


    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<PlayerEnergi>();
        enemy.Hurt(Damage);
        Destroy(transform.gameObject);
    }
}
