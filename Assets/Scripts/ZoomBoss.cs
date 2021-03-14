using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomBoss : MonoBehaviour
{
    Camera cam;
    FocusPlayer fp;

    [SerializeField] private float smooth = 5f;

    private Vector3 offset = new Vector3(0, 0, -60.0f);
    private bool faceToBoss = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        fp = cam.GetComponent<FocusPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (faceToBoss)
            cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + offset, smooth * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        faceToBoss = true;
        fp.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        faceToBoss = false;
        fp.enabled = true;
        fp.zoomIn();
    }
}
