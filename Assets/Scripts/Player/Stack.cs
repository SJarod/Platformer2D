using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private bool onLift = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle") && !onLift)
        {
            transform.position = new Vector3(other.transform.position.x, transform.position.y, 0);
            transform.parent = other.transform;
        }
        else if (other.CompareTag("Lift") && !onLift)
        {
            onLift = true;
            transform.parent = other.transform;
        }
        else
        {
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onLift = false;
        transform.parent = null;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(2, 1.25f, 2);
    }
}
