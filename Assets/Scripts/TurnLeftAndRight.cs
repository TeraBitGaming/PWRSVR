using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeftAndRight : MonoBehaviour
{
    private GameObject vrController;
    
    // Start is called before the first frame update
    void Start() {
        vrController = GameObject.FindGameObjectWithTag("Player"); 
    }

    public void InputReceived(string message) {
        if(message == "ROTATE-RIGHT") {
            vrController.transform.Rotate(new Vector3(0, 60, 0));
        }
        if(message == "ROTATE-LEFT") {
            vrController.transform.Rotate(new Vector3(0, -60, 0));
        }
    } 

    // public void ROTATE_RIGHT() {
    //     vrController.transform.Rotate(new Vector3(0, 60, 0));
    // }

    // public void ROTATE_LEFT() {
    //     vrController.transform.Rotate(new Vector3(0, -60, 0));
    // }
}
