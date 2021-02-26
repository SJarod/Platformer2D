using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]

public class ShootBox : MonoBehaviour
{
    Rigidbody rbBox;

    Move move;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rbBox == null)
            return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            rbBox.AddForce(Vector3.up * 10, ForceMode.Impulse);
            rbBox.AddForce(Vector3.right * move.orientation * 100, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
            rbBox = collision.gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision collision)
    {
        rbBox = null;
    }
}
