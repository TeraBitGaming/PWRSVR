using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheaterScript : MonoBehaviour
{
    private bool rotate;
    public Rigidbody rB;
    public float rotationX = 0;
    public float rotationY = 0;
    public float rotationZ = 0;

    public void doRotate() {
        rotate = true;
    }

    public void dontRotate() {
        rotate = false;
    }

    // Update is called once per frame
    void Update() {
        if (rotate == true) {
            rB.useGravity = false;
            gameObject.transform.Rotate(new Vector3(rotationX, rotationY, rotationZ));
        } else if (rotate == false) {
            rB.useGravity = true;
        }
    }
}
