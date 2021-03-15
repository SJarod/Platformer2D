using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPlayer : MonoBehaviour
{
    private GameObject  player;
    private GameObject  lift;

    [SerializeField] private float smooth = 5f;
    [SerializeField] private float liftZoomSpeed = 1.5f;

    public Vector3 offset = new Vector3(0, 3.0f, -12.0f);

    // Start is called before the first frame update
    void Start()
    {
        //camera focusing on the player and the lifts
        player = GameObject.FindGameObjectWithTag("Player");
        lift = GameObject.FindGameObjectWithTag("Lift");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(lift.transform.position.x,
                                     lift.transform.position.y,
                                     -(Mathf.Abs(lift.transform.position.y - player.transform.position.y) * liftZoomSpeed));

        transform.position = Vector3.Lerp(transform.position, newPos + offset, smooth * Time.fixedDeltaTime);
    }

    public void zoomIn()
    {
        offset = new Vector3(0, 3.0f, -12.0f);
    }

    public void zoomOut(Vector3 value)
    {
        offset = value;
    }

    public float getLiftY()
    {
        return lift.transform.position.y;
    }
}
