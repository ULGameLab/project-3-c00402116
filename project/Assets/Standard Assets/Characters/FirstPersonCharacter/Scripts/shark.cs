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
    private Rigidbody rigidbody;
    public UIManager uim;
    public float stunSeconds = 2.3f;

    public float health = 50f;
    public GameObject stunFX;

    private bool isStunned;

    // Start is called before the first frame update
    private void Start()
    {
        isStunned = false;
        rigidbody = GetComponent<Rigidbody>();
        uim = FindObjectOfType<UIManager>();
        stunFX.SetActive(false);
    }


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

    IEnumerator stunTime()
    {
        yield return new WaitForSeconds(stunSeconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }

    public void getStunned()
    {
        stunFX.SetActive(true);
        isStunned = true;
        StartCoroutine(stunTime());
        isStunned = false;
        stunFX.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        acceleration = Vector3.zero;

        if (!isStunned)
        {
            Seek();
        }
        Vector3 displacement = target.transform.position - transform.position;
        if (isStunned && displacement.magnitude < distanceThreshold)
        {
            rigidbody.velocity = Vector3.zero;
            acceleration = Vector3.zero;
        }

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;

    }
}
