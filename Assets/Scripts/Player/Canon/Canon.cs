using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject prefabObstacle;

    //number of boxes loaded in the canon
    private int loaded = 0;

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
        if (!collision.gameObject.CompareTag("Obstacle"))
            return;

        Destroy(collision.gameObject);
        ++loaded;
    }

    public void shoot()
    {
        if (loaded <= 0)
            return;

        GameObject go = Instantiate(prefabObstacle, new Vector3(0, 0, 2), Quaternion.identity);
        go.transform.SetParent(transform, false);

        Bullet blt = go.GetComponent<Bullet>();
        blt.damage = loaded;

        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        rb.velocity = Vector3.forward * 100;

        loaded = 0;
    }
}
