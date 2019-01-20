﻿using System;
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
    public bool heating;
    private int heat;
    public bool full;
    public bool pouring;
    public GameObject steam;

    public bool getPouring() {
        return pouring;
    }

    // Update is called once per frame
    void Update() {
        rotation = gameObject.transform.eulerAngles.x;
        xRot = Vector3.Angle(Vector3.up, transform.up);

        if (heating == true) {
            heat += 1;
        }
        if (heat == 100) {
            Debug.Log("DING!");
            hot = true;
            steam.SetActive(true);
        }



        if (hot == true && full == true){
            if (45 < xRot && rotation > 0) {
                pouring = true;
            } else {
                pouring = false;
            }
        }
    }
}