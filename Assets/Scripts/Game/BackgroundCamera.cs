using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCamera : MonoBehaviour
{
    private Camera mainCam;

    private float mainOffset = 56.3f;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        int offset = (int)(mainCam.transform.position.x / mainOffset);

        transform.position = new Vector3(mainCam.transform.position.x - offset * mainOffset, transform.position.y, 0);
    }
}
