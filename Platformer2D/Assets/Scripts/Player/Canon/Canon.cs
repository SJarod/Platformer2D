using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    //prefab for the bullet
    public GameObject       prefabBullet;

    //button cool down
    //button respawns after certain amount of time (after pressed)
    public float            buttonCD = 30f;
    public int              shootForce = 100;

    //number of boxes loaded in the canon
    private int             loaded = 0;
    private const int       maxLoad = 5;

    private CanonButton[]   button = new CanonButton[3];
    private CanonLed[]      led = new CanonLed[maxLoad];

    private float           gameSpeed;

    // Start is called before the first frame update
    void Start()
    {
        button[0] = GameObject.Find("button1").GetComponent<CanonButton>();
        button[1] = GameObject.Find("button2").GetComponent<CanonButton>();
        button[2] = GameObject.Find("button3").GetComponent<CanonButton>();

        led[0] = GameObject.Find("led1").GetComponent<CanonLed>();
        led[1] = GameObject.Find("led2").GetComponent<CanonLed>();
        led[2] = GameObject.Find("led3").GetComponent<CanonLed>();
        led[3] = GameObject.Find("led4").GetComponent<CanonLed>();
        led[4] = GameObject.Find("led5").GetComponent<CanonLed>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameSpeed = GameObject.Find("Canvas").GetComponent<Menu>().gameSpeed;

        for (int i = 0; i < 3; ++i)
        {
            if (Time.time - button[i].getOldTime() < buttonCD)
                return;

            button[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < maxLoad; ++i)
        {
            if (i < loaded)
                led[i].setGreen();
            else
                led[i].setRed();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (loaded >= maxLoad)
            return;

        if (!collision.gameObject.CompareTag("Obstacle"))
            return;

        Destroy(collision.gameObject);
        ++loaded;
    }

    public void shoot()
    {
        if (loaded <= 0)
            return;

        GameObject go = Instantiate(prefabBullet, new Vector3(0, 0, 2), Quaternion.identity);
        go.transform.SetParent(transform, false);

        Bullet blt = go.GetComponent<Bullet>();
        blt.damage = loaded;

        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        rb.velocity = Vector3.forward * shootForce * gameSpeed;

        loaded = 0;
    }
}
