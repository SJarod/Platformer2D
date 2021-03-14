using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
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
        if (player.transform.position.y <= -15)
        {
            player.GetComponent<Player>().takeDamage();
            Respawn(player);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().takeDamage();
            Respawn(collision.gameObject);
        }
    }

    private void Respawn(GameObject player)
    {
        player.transform.position = new Vector3(0, 3, 0);
    }
}
