using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    [SerializeField] Transform Shoot_Start;
    [SerializeField] int Fly_distance = 10;
    [SerializeField] int speed_shoot = 7;
    [SerializeField] GameObject Bomb;
    [SerializeField] Transform Player;
    [SerializeField] int Damage = 1;


    [SerializeField] int sped = 7;
    Vector3 direction;

    private void FixedUpdate()
    {
        transform.position += direction * speed_shoot * Time.deltaTime;

    }

    public void SetDirectionToPlayer(Vector3 dir)
    {
        
        direction = dir;
        
    }

}
