using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] int Enemy_Speed = 1;
    [SerializeField] Transform Player;
    [SerializeField] int area;
    int heals = 1;
    int Damage = 1;

    [SerializeField] Transform Shoot_Start;
    [SerializeField] int Fly_distance = 10;
    [SerializeField] int speed_shoot = 2;
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

    private void FixedUpdate()
    {
        if ((transform.position - Player.position).magnitude <= area && (transform.position - Player.position).magnitude >= 3f)
        {
            transform.LookAt(Player);
            Shoot();
            if ((Bomb.transform.position - Shoot_Start.position).magnitude > Fly_distance)
            {
                Destroy(Bomb.gameObject, 4.0f);
                Invoke("Shoot", 3.0f);

            }
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<PlayerEnergi>();
        enemy.Hurt(Damage);
        Destroy(transform.gameObject);
    }

    public void Shoot()
    {
        if(Bomb.gameObject == null)
        {
            Instantiate(Bomb, Shoot_Start.position, Shoot_Start.rotation);
            //Bomb.transform.position = Vector3.MoveTowards(Shoot_Start.position, Player.position, Time.deltaTime * speed_shoot);
            float force = Random.Range(750f, 1800f);
            Rigidbody rb = Bomb.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force);
        }
        

          
    }

}
    
