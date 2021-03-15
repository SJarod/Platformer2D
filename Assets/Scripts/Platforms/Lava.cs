using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public Vector3  respawnPoint = new Vector3(0, 3, 0);
    public float    limit = -15f;

    GameObject      player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is falling under the map
        if (player.transform.position.y <= limit)
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
        player.transform.position = respawnPoint;
    }
}
