using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherShoot : MonoBehaviour
{
    [SerializeField] GameObject ball;
    public Transform ShootSpawn;
    public float fireRate = 1;
    public float range = 15;
    public int Damage = 1;
    private float nextShoot = 1;
    private int Fly_distance = 17;
    public Transform Shoot_Start;
    int speed_shoot = 7;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextShoot)
        {
            nextShoot = Time.time + 2f / fireRate;
            Shooting();
        }
    }


    public void Shooting()
    {
        RaycastHit hit;

        Instantiate(ball, ShootSpawn.position, ShootSpawn.rotation);

        Fly(ball);
       
        

        //if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        //{
        //    if (hit.collider != null)
        //    {

        //        var enemy = hit.collider.gameObject.GetComponent<Enemies>();
        //        enemy.Hurt(Damage);
        //        Destroy(transform.gameObject);
                
        //            //meObject.transform.position.AddForce(-hit.normal * 45);   //отталкивание предмета
        //    }
        //}

        //if ((transform.position - Shoot_Start.position).magnitude > Fly_distance)
        //{
        //    Destroy(gameObject);

        //}
    }

    public void Fly(GameObject gameObject)
    {
        float force = Random.Range(750f, 1800f);
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
        //gameObject.transform.Translate(Vector3.forward * speed_shoot * Time.deltaTime);
             
        Destroy(gameObject, 4.0f);

        
    }
}
