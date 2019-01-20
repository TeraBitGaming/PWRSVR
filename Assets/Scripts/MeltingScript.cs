using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltingScript : MonoBehaviour
{
    private bool doPour;
    private BoxCollider boxC;
    private GameObject kettle;
    private GameObject key;

    void Start() {
        boxC = gameObject.GetComponent<BoxCollider>();
        kettle = GameObject.FindGameObjectWithTag("Kettle");
        key = GameObject.FindGameObjectWithTag("Key");
    }

    void OnTriggerStay(Collider other) {
        Debug.Log("Stayed in the collider");
        if (other.tag == "Kettle" || other.tag == "Water"){
            doPour = true;
        }
    }
    void OnTriggerExit(Collider other) {
        Debug.Log("Left collider");
        doPour = false;
    }

    // Update is called once per frame
    void Update() {
        if (doPour == true && transform.localScale.z > 0 && kettle.GetComponent<WaterJugScript>().getPouring() == true) {
            transform.localScale -= new Vector3(0, 0, 0.005F);
            boxC.size += new Vector3(0, 0, 0.21f);
            boxC.center += new Vector3(0, 0, 0.05f);
        }
        if (transform.localScale.z < 0.05) {
            key.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
