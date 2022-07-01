using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform FollowObject;
    public int speed = 4;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, FollowObject.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, FollowObject.rotation, speed * Time.deltaTime);
    }
}
