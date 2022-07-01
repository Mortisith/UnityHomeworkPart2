using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShoot : MonoBehaviour
{
    [SerializeField] int sped = 7;
    Vector3 direction;

    private void FixedUpdate()
    {
        transform.position += direction * sped * Time.deltaTime;
        
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
}
