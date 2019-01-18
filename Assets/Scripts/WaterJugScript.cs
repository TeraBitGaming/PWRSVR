using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterJugScript : MonoBehaviour
{
    private float xRot;
    private float rotation;
    
    // private double yRot;
    // private double zRot;
    public bool hot;
    public Light babyLight;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        rotation = gameObject.transform.eulerAngles.x;
        xRot = Vector3.Angle(Vector3.up, transform.up);

        if (45 < xRot && rotation > 0) {
            babyLight.enabled = true;
        } else {
            babyLight.enabled = false;
        }
    }
}