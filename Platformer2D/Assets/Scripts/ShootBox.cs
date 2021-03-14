using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBox : MonoBehaviour
{
    Rigidbody rbBox;

    Move move;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponentInParent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rbBox == null)
            return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            rbBox.AddForce(Vector3.up * 10, ForceMode.Impulse);
            rbBox.AddForce(Vector3.right * move.getOrientation() * 100, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
            rbBox = other.gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        rbBox = null;
    }
}
