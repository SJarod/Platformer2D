﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        ContactPoint[] contacts = new ContactPoint[8];

        for (int i = 0; i < collision.GetContacts(contacts); ++i)
        {
            if (contacts[i].normal.y >= 0.0f)
            {
                //Debug.Log("GAME OVER");
                //Application.Quit();
                Respawn(collision.gameObject);
                break;
            }
        }
    }

    private void Respawn(GameObject player)
    {
        player.transform.position = new Vector3(0, 3, 0);
    }
}
