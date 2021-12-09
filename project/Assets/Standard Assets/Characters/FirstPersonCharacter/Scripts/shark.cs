using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shark : MonoBehaviour
{

    private Vector3 acceleration;
    public GameObject target;
    public float speed;
    public float distanceThreshold;
    private Vector3 desiredVelocity;
    public Vector3 velocity;
    private Vector3 steeringForce;

    // Start is called before the first frame update

    void Seek()
    {

        Vector3 displacement = target.transform.position - transform.position;
        if (displacement.magnitude > distanceThreshold)
        {
            Vector3 directionToTarget = displacement.normalized;
            Vector3 desiredVelocity = directionToTarget * speed;
            Vector3 steeringForce = desiredVelocity - velocity;

            acceleration += steeringForce;
        }
        //print(acceleration + "   seek");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        acceleration = Vector3.zero;

        Seek();

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;

        
    }
}
