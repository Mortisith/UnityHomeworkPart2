using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    [SerializeField] int Damage = 1;
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }


    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<PlayerEnergi>();
        enemy.Hurt(Damage);
        anim.Play();
        //Destroy(transform.gameObject);

    }

}
