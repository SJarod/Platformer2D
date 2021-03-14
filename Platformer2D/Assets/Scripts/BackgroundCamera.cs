using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCamera : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;

    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        int offset = (int)(mainCam.transform.position.x / 56.3f);

        transform.position = new Vector3(mainCam.transform.position.x - offset * 56.3f, transform.position.y, 0);
    }
}
