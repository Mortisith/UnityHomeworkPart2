using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] int EnergiCount = 1;
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<PlayerEnergi>();
        enemy.Healing(EnergiCount);

        transform.gameObject.SetActive(false);
        anim.Stop();
        Destroy(transform.gameObject);
    }
}
