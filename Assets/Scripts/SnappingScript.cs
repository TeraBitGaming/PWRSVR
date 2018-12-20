using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappingScript : MonoBehaviour
{
    public Transform Self;
    public Rigidbody RB;
    public Transform Target;
    public float requiredDistance;

    public bool isLocked = false;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Self.position, Target.position) < requiredDistance){
            RB.isKinematic = true;
            gameObject.transform.position = Target.position;
            gameObject.transform.rotation = Target.rotation;
            isLocked = true;
        } else if (Vector3.Distance(Self.position, Target.position) > requiredDistance){
            RB.isKinematic = false;
            isLocked = false;
        }
    }
}
