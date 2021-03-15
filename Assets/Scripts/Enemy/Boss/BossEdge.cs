using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEdge : MonoBehaviour
{
    //left : -1, right : 1
    public int  sideEdge = 1;

    private BossMove    boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("BossEntity"))
            return;

        boss = other.gameObject.GetComponent<BossMove>();
        boss.onEdge(sideEdge);
    }
}
