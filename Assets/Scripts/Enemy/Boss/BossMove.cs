using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BossMove : MonoBehaviour
{
    public float bossSpeed = 10f;

    private int direction = 1;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * direction * bossSpeed * Time.fixedDeltaTime;
    }

    public void onEdge(int whichEdge)
    {
        if (whichEdge == -1)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else if (whichEdge == 1)
            transform.rotation = Quaternion.Euler(0, 180, 0);

        direction = -whichEdge;
    }
}
