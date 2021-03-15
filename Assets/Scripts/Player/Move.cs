using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Move : MonoBehaviour
{
    Rigidbody       rb;
    Camera          cam;

    private bool    isJumping = false;

    public int      moveSpeed = 10;
    public int      jumpForce = 10;

    public int      rotatingSpeed = 10;

    private int     baseMoveSpeed;
    private int     baseJumpForce;

    //direction is used for moving
    //orientation is used for shooting
    //-1 : left, 1 : right
    int direction = 0;          //player's direction (direction vector, left or right)
    int orientation = 1;

    private float gameSpeed;

    // Start is called before the first frame update
    void Start()
    {
        baseMoveSpeed = moveSpeed;
        baseJumpForce = jumpForce;

        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = GameObject.Find("Canvas").GetComponent<Menu>().gameSpeed;

        if (!Input.GetButton("Horizontal"))
            direction = 0;
        else
        {
            float input = Input.GetAxis("Horizontal");
            direction = (int)(input / Mathf.Abs(input));
        }

        if (!Input.GetKey(KeyCode.LeftShift) && direction != 0)
            orientation = direction;

        orientationRotation();

        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            if (rb.velocity.y > 0)
                rb.velocity = new Vector3(rb.velocity.x * gameSpeed, (rb.velocity.y + jumpForce) * gameSpeed, 0);
            else
                rb.velocity = new Vector3(rb.velocity.x * gameSpeed, jumpForce * gameSpeed, 0);
        }

        rb.velocity = new Vector3(direction * moveSpeed * gameSpeed, rb.velocity.y * gameSpeed, 0);
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

    public int getBaseMoveSpeed()
    {
        return baseMoveSpeed;
    }

    public int getBaseJumpForce()
    {
        return baseJumpForce;
    }

    private void orientationRotation()
    {
        if (orientation == -1)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotatingSpeed);
        else if (orientation == 1)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), Time.deltaTime * rotatingSpeed);
    }
}
