using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    [SerializeField] int Damage = 1;


    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<PlayerEnergi>();
        enemy.Hurt(Damage);
        Destroy(transform.gameObject);
    }

}
