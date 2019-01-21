using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourChecker : MonoBehaviour {
    
    public bool isFull = false;

    // Update is called once per frame
    void OnTriggerStay(Collider other) {
        if (other.tag == "Kettle" || other.tag == "Water" || other.tag == "Steam"){
            isFull = true;
        }
    }
}
