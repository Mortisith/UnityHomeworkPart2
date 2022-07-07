using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergi : MonoBehaviour
{
    [SerializeField] int heals = 6;

    public HealthBar healthBar;

    void Start()
    {
        healthBar.MaxHeals(heals);
    }

    public void Healing (int count)
    {
        heals += count;
    }
    public void Hurt(int count)
    {
        heals -= count;
        healthBar.SetHeals(heals);
        if (heals <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Trap")
            Hurt(1);
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
