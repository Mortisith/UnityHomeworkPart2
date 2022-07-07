using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsar : MonoBehaviour
{
    [SerializeField] int Damage = 2;
   
    [SerializeField] Transform Transform_Pulsar_Spawn;
    [SerializeField] int speed_shoot = 2;
    private int Fly_distance = 17;
    public Transform Shoot_Start;



    //private void OnTriggerEnter(Collider other)
    //{
    //    var enemy = other.GetComponent<Enemies>();
    //    enemy.Hurt(Damage);
    //    Destroy(gameObject);
    //}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") )
        {
            Instantiate(gameObject, Transform_Pulsar_Spawn.position, Transform_Pulsar_Spawn.rotation);
            Fly();
        }
    }

    public void Fly()
    {
        transform.Translate(Vector3.forward * speed_shoot * Time.deltaTime);
        if ((transform.position - Shoot_Start.position).magnitude > Fly_distance)
        {
            Destroy(gameObject);

        }
        if ((transform.position - Shoot_Start.position).magnitude > Fly_distance)
        {
            Destroy(gameObject);

        }
    }
}
