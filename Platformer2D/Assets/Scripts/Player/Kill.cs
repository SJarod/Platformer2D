using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public float    bounceOnEnemy = 5f;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy")
            return;

        Destroy(other.gameObject);
        Rigidbody rb = GetComponentInParent<Rigidbody>();

        rb.velocity = new Vector3(rb.velocity.x * gameSpeed, bounceOnEnemy * gameSpeed, 0);
    }
}
