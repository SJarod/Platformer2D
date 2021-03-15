using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float    liftSpeed = 10.0f;
    public float    min = 15f;
    public float    max = 25f;

    private int     direction = 1;

    private float   gameSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameSpeed = GameObject.Find("Canvas").GetComponent<Menu>().gameSpeed;

        changeDirection();

        transform.position += Vector3.up * direction * liftSpeed * Time.deltaTime * gameSpeed;
    }

    private void changeDirection()
    {
        if (transform.position.y <= transform.parent.position.y - min)
            direction = 1;
        if (transform.position.y >= transform.parent.position.y + max)
            direction = -1;
    }
}
