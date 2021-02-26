using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPlayer : MonoBehaviour
{
    GameObject player;
    GameObject lift;

    // Start is called before the first frame update
    void Start()
    {
        //camera focusing on the player and the lifts
        player = GameObject.FindGameObjectWithTag("Player");
        lift = GameObject.FindGameObjectWithTag("Lift");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(lift.transform.position.x,
                                         player.transform.position.y,
                                         -(Mathf.Abs(lift.transform.position.y - player.transform.position.y)));
        transform.Translate(new Vector3(0, 3, -12));

        //coroutine pour fluidifier la rotation
    }
}
