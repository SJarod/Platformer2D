using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPlayer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //camera focusing on the lifts
        player = GameObject.FindGameObjectWithTag("Lift");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.Translate(new Vector3(0, 3, -12));
    }
}
