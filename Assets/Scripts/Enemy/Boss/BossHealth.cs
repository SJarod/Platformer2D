﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int      health = 5;
    public float    dmgCoolDown = 1f;

    private float   oldTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int dmg)
    {
        if (Time.time - oldTime < dmgCoolDown)
            return;

        oldTime = Time.time;

        health -= dmg;
    }
}
