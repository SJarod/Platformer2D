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
    public float jumpForce = 20.0f;

    //-1 : left, 1 : right
    int direction = 0;          //player's direction (direction vector, left or right)
    int orientation = 1;

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

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (direction == -1)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                orientation = -1;
            }
            else if (direction == 1)
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
                orientation = 1;
            }
        }

        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        rb.velocity = new Vector3(direction * 10, rb.velocity.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
            return;

        isJumping = false;
    }

    public int getOrientation()
    {
        return orientation;
    }
}
