using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public int PlugCount = 0;

    public GameObject light1;
    public GameObject light2;
    public GameObject plug1;
    public GameObject Plug2;
    public GameObject Plug3;
    public GameObject[] pipes;
    public GameObject waterPipe;
    private GameObject kettle;

    public int energyDrained = 0;

    void Start() {
        pipes = GameObject.FindGameObjectsWithTag("Pipe");
        kettle = GameObject.FindGameObjectWithTag("Kettle");
    }

    // Update is called once per frame
    void Update()
    {
        PlugCount = plug1.GetComponent<NewSnapper>().getSentSignal() + Plug2.GetComponent<NewSnapper>().getSentSignal() + Plug3.GetComponent<NewSnapper>().getSentSignal();
        if (PlugCount == 3){
            light1.GetComponent<Light>().enabled = true;
            light2.GetComponent<Light>().enabled = true;
            energyDrained += 2;
        } else if (PlugCount < 3){
            light1.GetComponent<Light>().enabled = false;
            light2.GetComponent<Light>().enabled = false;
        }

        int ctr = 0;
        foreach (GameObject pipe in pipes) {
            ctr += pipe.GetComponent<NewSnapper>().getSentSignal();
        }
        if (ctr == 27) {
            Debug.Log("Pipes work!");
            kettle.GetComponent<WaterJugScript>().heating = true;
        } else {
            kettle.GetComponent<WaterJugScript>().heating = false;
        }

        if(waterPipe.GetComponent<NewSnapper>().getSentSignal() == 1){
            kettle.GetComponent<WaterJugScript>().full = true;
            Debug.Log("Water-pipe works too!");
        } else {
            kettle.GetComponent<WaterJugScript>().full = false;
        }
    }
}

// PlugCount = GameController.GetComponent<GameControllerScript>().PlugCount;

