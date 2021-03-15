using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float    bumpForce = 20f;

    private float   gameSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = GameObject.Find("Canvas").GetComponent<Menu>().gameSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x * gameSpeed, bumpForce * gameSpeed, 0);
    }
}
