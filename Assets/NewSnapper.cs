﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSnapper : MonoBehaviour
{
    public GameObject target;
    private Transform targetTransform;
    private Rigidbody targetRB;
    public float requiredDistance;
    public string snapTag;
    public bool useTags;
    private Transform self;
    private Rigidbody selfRB;
    private bool connected;
    private GameObject[] gos;

    public bool lockXRotation;
    public bool lockYRotation;
    public bool lockZRotation;
    public bool lockAllRotation;
    public bool lockXAxis;
    public bool lockYAxis;
    public bool lockZAxis;
    public bool lockAllAxis;
    public bool lockAll;
    public bool copyTransform;

    private void startSnapping(){
        if (Vector3.Distance(self.position, targetTransform.position) < requiredDistance && connected == false){
            if(copyTransform == true){
                gameObject.transform.position = targetTransform.position;
                gameObject.transform.rotation = targetTransform.rotation;
            }
            gameObject.AddComponent<SpringJoint>();
            gameObject.GetComponent<SpringJoint>().connectedBody = targetRB;
            gameObject.GetComponent<SpringJoint>().spring = 1000;
            gameObject.GetComponent<SpringJoint>().tolerance = 0;
            connected = true;
            if (lockXRotation == true){
                selfRB.constraints = RigidbodyConstraints.FreezeRotationX;
            }
            if (lockYRotation == true){
                selfRB.constraints = RigidbodyConstraints.FreezeRotationY;
            }
            if (lockZRotation == true){
                selfRB.constraints = RigidbodyConstraints.FreezeRotationZ;
            }
            if (lockAllRotation == true){
                selfRB.constraints = RigidbodyConstraints.FreezeRotation;
            }
            if (lockXAxis == true){
                selfRB.constraints = RigidbodyConstraints.FreezePositionX;
            }
            if (lockYAxis == true){
                selfRB.constraints = RigidbodyConstraints.FreezePositionY;
            }
            if (lockZAxis == true){
                selfRB.constraints = RigidbodyConstraints.FreezePositionZ;
            }
            if (lockAllAxis == true){
                selfRB.constraints = RigidbodyConstraints.FreezePosition;
            }
            if (lockAll == true){
                selfRB.constraints = RigidbodyConstraints.FreezeAll;
            }

        } 
        else if(Vector3.Distance(self.position, targetTransform.position) > requiredDistance){
            Destroy(gameObject.GetComponent<SpringJoint>());
            selfRB.constraints = RigidbodyConstraints.None;
            connected = false;
        }
    }

    
    // Start is called before the first frame update
    void Start(){
        self = gameObject.GetComponent<Transform>();
        selfRB = gameObject.GetComponent<Rigidbody>();
        targetTransform = target.GetComponent<Transform>();
        targetRB = target.GetComponent<Rigidbody>();
        gos = GameObject.FindGameObjectsWithTag(snapTag);
    }

    // Update is called once per frame
    void Update(){
        
        // Snippet taken from second example in page:
        // https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        
        // Here ends the snippet

        if(useTags == true) {
            Debug.Log(closest);
            targetTransform = closest.GetComponent<Transform>();
            targetRB = closest.GetComponent<Rigidbody>();
            startSnapping();
        } else if (useTags == false) {
            startSnapping();
        }
    }
}