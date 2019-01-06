using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public int PlugCount = 0;

    public GameObject Plug1;
    public GameObject Plug2;
    public GameObject Plug3;

    // Update is called once per frame
    void Update()
    {
        PlugCount = Plug1.GetComponent<SnappingScript>().IsPlugged + Plug2.GetComponent<SnappingScript>().IsPlugged + Plug3.GetComponent<SnappingScript>().IsPlugged;
        if (PlugCount == 3){
            Debug.Log("yippiee!");
        }
    }
}
// PlugCount = GameController.GetComponent<GameControllerScript>().PlugCount;