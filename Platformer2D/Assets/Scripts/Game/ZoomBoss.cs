using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomBoss : MonoBehaviour
{
    Camera cam;
    FocusPlayer fp;

    [SerializeField] private float smooth = 5f;

    private Vector3 offset = new Vector3(0, 0, -45f);
    private Boss b;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        fp = cam.GetComponent<FocusPlayer>();
        b = GetComponent<Boss>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset = new Vector3(0, Mathf.Clamp(fp.getLiftY() - transform.position.y, -25, 25), offset.z);

        if (b.isOnFight())
            cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + offset, smooth * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        fp.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        fp.enabled = true;
        fp.zoomIn();
    }
}
