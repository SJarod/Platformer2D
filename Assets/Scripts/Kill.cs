﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy")
            return;

        Destroy(other.gameObject);
        GetComponentInParent<Rigidbody>().AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
    }
}
