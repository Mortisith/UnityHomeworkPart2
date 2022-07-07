using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;

    [SerializeField] float player_speed = 3;
    private Vector3 Vector3_player_Direction = Vector3.zero;
    float timer = 0;
    [SerializeField] private int jumpForce = 2;
    Vector3 GravityVelocity;
    [SerializeField] float gravityForce = 9.81f;
    Vector3 Vector3_Angular;
    private bool isGrounded = true;
    Vector3 MoveDirection = Vector3.zero;
    public float turnSpeed = 20f;
    





    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Quaternion newRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 5 * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Quaternion newRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 5 * Time.deltaTime);
        }
        

    }

    void Update()
    {
        Vector3_player_Direction.x = Input.GetAxis("Horizontal") * player_speed/10;
        Vector3_player_Direction.z = Input.GetAxis("Vertical") *player_speed/10;

        if (GravityVelocity.y < 0)
        {
            GravityVelocity.y = 0;
        }
        GravityVelocity.y -= gravityForce * 20* Time.deltaTime;


        if (Input.GetButtonDown("Jump") && controller.isGrounded) 
        {
            GravityVelocity.y += Mathf.Sqrt(jumpForce * 3.0f * gravityForce);
        }

        controller.Move(transform.TransformDirection(Vector3_player_Direction) + GravityVelocity * Time.deltaTime);
    }


}
