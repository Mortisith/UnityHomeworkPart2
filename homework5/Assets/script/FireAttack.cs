using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    [SerializeField] Transform Shoot_Start;
    [SerializeField] int Fly_distance = 10;
    [SerializeField] int speed_shoot = 2;
    [SerializeField] GameObject Bomb;
    [SerializeField] Transform Player;
    [SerializeField] int Damage = 1;



    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<PlayerEnergi>();
        enemy.Hurt(Damage);
        Destroy(transform.gameObject);
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if ((transform.position - Player.position).magnitude <= 15)
        {
           
            transform.LookAt(Player);
            transform.position = Vector3.MoveTowards(transform.position, Player.position, Time.deltaTime * speed_shoot);
            transform.Translate(transform.forward * speed_shoot * 10 * Time.deltaTime);
            Destroy(gameObject, 4.0f);

        }

        
        //if ((transform.position - Shoot_Start.position).magnitude == 0)
        //{
        //    Instantiate(Bomb, Shoot_Start.position, Shoot_Start.rotation);
        //}


            
    }
}
