﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEdge : MonoBehaviour
{
    EnemyMove enemy;

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
        if (!other.CompareTag("Enemy"))
            return;

        enemy = other.gameObject.GetComponent<EnemyMove>();
        enemy.rotation180();
    }
}
