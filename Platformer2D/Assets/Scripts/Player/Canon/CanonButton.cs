using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonButton : MonoBehaviour
{
    Canon canon;

    private float oldTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        canon = GetComponentInParent<Canon>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        canon.shoot();
        this.gameObject.SetActive(false);

        oldTime = Time.time;
    }

    public float getOldTime()
    {
        return oldTime;
    }
}
