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
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            rb.AddForce(cam.transform.right * Input.GetAxis("Horizontal") * moveSpeed * rb.mass);
        }

        if (direction == -1 && Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 180 * direction);
            direction = 1;
        }
        if (direction == 1 && Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, 180 * direction);
            direction = -1;
        }

        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -10, 10), rb.velocity.y, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
