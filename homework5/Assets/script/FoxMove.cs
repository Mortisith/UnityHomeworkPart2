using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxMove : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] float Player_Sped = 10f;
   
    Vector3 Velocity;
    public float gravity = 9.81f;
    bool isGrounded;
    public float GroundDistance = 0.4f;
    public LayerMask Ground;
    public Transform CheckMask;
    public float jumpForse = 5f;


    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(CheckMask.position, GroundDistance, Ground);
        
        if (controller.isGrounded && Velocity.y < 0)
        {
            Velocity.y = 0f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            Velocity.y = Mathf.Sqrt(jumpForse * 2f * gravity);
        }


        //if (Input.GetButtonDown("Jump") && controller.isGrounded)
        //{
        //    Velocity.y += Mathf.Sqrt(jumpForse * 3.0f * gravity);
        //}

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * Player_Sped * Time.deltaTime);
        Velocity.y -= gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);

    }

}