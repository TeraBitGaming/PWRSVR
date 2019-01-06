using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappingScript : MonoBehaviour
{
    private Transform Self;
    private Rigidbody RB;
    private GameObject GameController;
    public int IsPlugged = 0;
    public Transform Target;
    public float requiredDistance;
    
    private bool isLocked = false;

    public bool PushPlug = false;

    void Start(){
        GameController = GameObject.Find("GameStateController");
        Self = gameObject.GetComponent<Transform>();
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Self.position, Target.position) < requiredDistance){
            RB.isKinematic = true;
            gameObject.transform.position = Target.position;
            gameObject.transform.rotation = Target.rotation;
            isLocked = true;
            if (PushPlug == true){
                IsPlugged = 1;
            }
        } else if (Vector3.Distance(Self.position, Target.position) > requiredDistance){
            RB.isKinematic = false;
            isLocked = false;
        }
    }
}
