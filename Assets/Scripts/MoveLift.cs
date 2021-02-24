using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLift : MonoBehaviour
{
    GameObject player;

    public float liftSpeed = 5.0f;

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

        //TODO : launch box to take out enemies
        //TODO : new range for new level
        float maxHeight = player.transform.position.y + 2.5f;
        float minHeight = player.transform.position.y - 2.5f;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
    }
}
