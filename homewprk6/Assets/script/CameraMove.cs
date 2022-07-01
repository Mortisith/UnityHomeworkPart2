using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform PlayerBody;
    public float mousesence = 100f;
    float xRotation = 0f;

    //public Transform FollowObject;
    //public int speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesence * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesence * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);

    }

    //private void FixedUpdate()
    //{
    //    transform.position = Vector3.Lerp(transform.position, FollowObject.position, speed * Time.deltaTime);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, FollowObject.rotation, speed * Time.deltaTime);
    //}


}
