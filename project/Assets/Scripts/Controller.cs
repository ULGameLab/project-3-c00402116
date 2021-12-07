using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 velocity;
    Vector3 acceleration;
    float speed = 10f;
    float maxSpeed = 15f;

    void GetInput()
    {
        Vector3 movementY = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized;
        Vector3 movementX = new Vector3(0, 0, Input.GetAxisRaw("Vertical")).normalized;
        //Vector3 movement = (movementY + movementX) * transform.forward;
        acceleration = (movementY + movementX) * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;
    }
}
