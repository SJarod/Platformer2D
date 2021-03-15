using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyMove : MonoBehaviour
{
    private Rigidbody   rb;

    public float        moveSpeed = 10.0f;
    public Vector3      dirAxis = new Vector3(0, 0, 1);

    public bool         isSmart = false;

    //-1 : left, 1 : right
    int             direction;

    private float   gameSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (dirAxis.x == 0)
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
        else if (dirAxis.z == 0)
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

        direction = (int)(transform.position.z / Mathf.Abs(transform.position.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameSpeed = GameObject.Find("Canvas").GetComponent<Menu>().gameSpeed;

        if (isSmart)
        {
            Vector3 target = transform.parent.gameObject.GetComponentInChildren<SmartEnemyRange>().getTarget();

            //work in progress
            if (target.x != 0)
                direction = (int)((target.x + transform.position.x) / Mathf.Abs(target.x + transform.position.x));
            else
                direction = 0;
        }

        rb.velocity = dirAxis * -direction * moveSpeed * gameSpeed;
    }

    public void rotation180()
    {
        transform.Rotate(Vector3.up, 180);
        direction *= -1;
    }
}
