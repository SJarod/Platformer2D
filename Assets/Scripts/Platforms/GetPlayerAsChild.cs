﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerAsChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        collision.gameObject.transform.parent = transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        collision.gameObject.transform.parent = null;
    }
}
