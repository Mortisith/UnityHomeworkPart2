using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergi : MonoBehaviour
{
    [SerializeField] int heals = 6;

    public void Healing (int count)
    {
        heals += count;
    }
    public void Hurt(int count)
    {
        heals -= count;
        if (heals <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
