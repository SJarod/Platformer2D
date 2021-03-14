using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    Camera cam;
    FocusPlayer fp;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        fp = cam.GetComponent<FocusPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        fp.zoomOut(new Vector3(0, 3.0f, -25.0f));
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        fp.zoomIn();
    }
}
