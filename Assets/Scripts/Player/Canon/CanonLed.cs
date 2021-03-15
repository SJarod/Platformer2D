using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]

public class CanonLed : MonoBehaviour
{
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setRed()
    {
        mat.color = Color.red;
    }

    public void setGreen()
    {
        mat.color = Color.green;
    }
}
