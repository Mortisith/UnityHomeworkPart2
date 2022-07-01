using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretOpen : MonoBehaviour
{
    //[SerializeField] Animator Secret;
    //[SerializeField] Animator Plunge;
    Animation anim;
    
    public bool isTouch = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Plunge.SetBool("IsStay", true);
            //Secret.SetBool("isPlungeTouch", true);

            Debug.Log("Touch");
            anim.Play();
            isTouch = true;
            
        }
        else
        {
            isTouch = false;
        }


    }

    public bool GetisTouch()
    {
        return isTouch;
    }

    private void Start()
    {
        //Secret = transform.Find("SecretDoor").GetComponent<Animator>();
        //Plunge = transform.Find("decorative_plant_desk (4)").GetComponentInChildren<Animator>();
        anim = GetComponent<Animation>();
    }
}
