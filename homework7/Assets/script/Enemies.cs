using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] int Enemy_Speed = 1;
    [SerializeField] Transform Player;
    [SerializeField] int area;
    int heals = 3;
    int Damage = 3;

    [SerializeField] Transform Shoot_Start;
    [SerializeField] int Fly_distance = 10;
    [SerializeField] int speed_shoot = 7;
    [SerializeField] GameObject Bomb;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
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



    void Update()
    {
        if ((transform.position - Player.position).magnitude <= area)
        {
            transform.LookAt(Player.position);
            Invoke("Shoot", 3.0f);
        }

    }



//private void FixedUpdate()
//    {
//        if ((transform.position - Player.position).magnitude <= area && (transform.position - Player.position).magnitude >= 3f)
//        {
//            transform.LookAt(Player);
//            Shoot();
//            if ((Bomb.transform.position - Shoot_Start.position).magnitude > Fly_distance)
//            {
//                Destroy(Bomb.gameObject, 4.0f);
//                Invoke("Shoot", 3.0f);

//            }
//        }
        

    
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<PlayerEnergi>();
        enemy.Hurt(Damage);
        Destroy(transform.gameObject);
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bomb")
        {
            
            Hurt(1);
        }
    }

    public void Shoot()
    {


        GameObject NewBomb = Instantiate(Bomb, Shoot_Start.position, Shoot_Start.rotation);
        NewBomb.GetComponent<FireAttack>().SetDirectionToPlayer(Shoot_Start.forward);
        Destroy(NewBomb.transform.gameObject, 3f);

    }

}
    
