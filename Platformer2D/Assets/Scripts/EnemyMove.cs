using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyMove : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed = 20.0f;

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
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -direction * 10);
    }

    public void rotation180()
    {
        transform.Rotate(Vector3.up, 180);
        direction *= -1;
    }
}
