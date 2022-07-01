using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoorOpen : MonoBehaviour
{
    //[SerializeField] Animation Secret;
    //[SerializeField] Animation Plunge;
    [SerializeField] bool secret;

    Animation anim;
    void Start()
    {
        //Secret = GetComponent<Animation>();
        //Plunge = GetComponentInChildren<Animation>();
        secret = GetComponent<secretOpen>().GetisTouch();

        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (secret) anim.Play();
    }
}
