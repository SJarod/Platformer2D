using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float liftSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO : meme systeme que EnemyMove
        transform.position += Vector3.up * Mathf.Cos(Time.time) * 4 * liftSpeed * Time.deltaTime;
    }
}
