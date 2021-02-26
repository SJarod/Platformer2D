using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Move : MonoBehaviour
{
    Rigidbody rb;
    Camera cam;

    bool isJumping = false;

    public float moveSpeed = 20.0f;
    public float jumpForce = 10.0f;

    //-1 : left, 1 : right
    int direction = 0;
    public int orientation = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("Horizontal"))
            direction = 0;
        else
        {
            float input = Input.GetAxis("Horizontal");
            direction = (int)(input / Mathf.Abs(input));
        }

        if (orientation == -1 && Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 180 * orientation);
            orientation = 1;
        }
        if (orientation == 1 && Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, 180 * orientation);
            orientation = -1;
        }

        if (!isJumping && Input.GetButton("Jump"))
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        rb.velocity = new Vector3(direction * 10, rb.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
