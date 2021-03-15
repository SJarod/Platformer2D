using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBox : MonoBehaviour
{
    Rigidbody   rbBox;
    Move        move;

    public float    shootForce = 10f;

    private float   gameSpeed;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponentInParent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = GameObject.Find("Canvas").GetComponent<Menu>().gameSpeed;

        if (rbBox == null)
            return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            float force = shootForce * 10f;

            rbBox.AddForce(Vector3.up * shootForce * gameSpeed, ForceMode.Impulse);
            rbBox.AddForce(Vector3.right * move.getOrientation() * force * gameSpeed, ForceMode.Impulse);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
            rbBox = other.gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        rbBox = null;
    }
}
