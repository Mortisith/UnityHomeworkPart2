using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsarAttack : MonoBehaviour
{
    [SerializeField] GameObject GameObject_Pulsar;
    [SerializeField] Transform Transform_Pulsar_Spawn;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(GameObject_Pulsar, Transform_Pulsar_Spawn.position, Transform_Pulsar_Spawn.rotation);
            float force = Random.Range(750f, 1800f);
            Rigidbody rb = GameObject_Pulsar.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force);

        }
    }
}
