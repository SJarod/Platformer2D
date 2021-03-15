using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemyRange : MonoBehaviour
{
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        target = other.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        target = Vector3.zero;
    }

    public Vector3 getTarget()
    {
        return target;
    }
}
