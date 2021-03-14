using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLift : MonoBehaviour
{
    GameObject player;

    public float liftSpeed = 5.0f;
    public float maxLift = 2.5f;

    private float fromPlayerY = 0.34f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //TODO : button to speed up lifts
        if (Input.GetButton("Vertical"))
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * liftSpeed * Time.deltaTime);

        float maxHeight = player.transform.position.y + maxLift;
        float minHeight = player.transform.position.y - fromPlayerY;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
    }
}
