using System.Collections;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Obstacle")
            return;

        ContactPoint[] contacts = new ContactPoint[8];

        Debug.Log("salut");
        for (int i = 0; i < collision.GetContacts(contacts); ++i)
        {
            Debug.Log(i);
            Debug.Log(contacts[i].normal.y);
            if (contacts[i].normal.y <= 0.0f)
            {
                //Debug.Log("GAME OVER");
                //Application.Quit();
                Destroy(this.gameObject);
                break;
            }
        }
    }
}
