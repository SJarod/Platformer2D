using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int          damage = 1;

    private BossHealth  boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("BossEntity").GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("BossEntity"))
            return;

        boss.takeDamage(damage);
        Destroy(this.gameObject);
    }
}
