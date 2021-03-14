using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyMove : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed = 10.0f;
    public Vector3 dirAxis = new Vector3(0, 0, 1);

    //-1 : left, 1 : right
    int direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
        direction = (int)(transform.position.z / Mathf.Abs(transform.position.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = dirAxis * -direction * moveSpeed;
    }

    public void rotation180()
    {
        transform.Rotate(Vector3.up, 180);
        direction *= -1;
    }
}
