using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public int PlugCount = 0;

    public GameObject light1;
    public GameObject light2;
    public GameObject Plug1;
    public GameObject Plug2;
    public GameObject Plug3;
    public GameObject[] Pipes;
    public GameObject waterPipe;

    void Start() {
        Pipes = GameObject.FindGameObjectsWithTag("Pipe");
    }

    // Update is called once per frame
    void Update()
    {
        PlugCount = Plug1.GetComponent<NewSnapper>().getSentSignal() + Plug2.GetComponent<NewSnapper>().getSentSignal() + Plug3.GetComponent<NewSnapper>().getSentSignal();
        if (PlugCount == 3){
            light1.GetComponent<Light>().enabled = true;
            light2.GetComponent<Light>().enabled = true;
        } else if (PlugCount < 3){
            light1.GetComponent<Light>().enabled = false;
            light2.GetComponent<Light>().enabled = false;
        }

        int ctr = 0;
        foreach (GameObject pipe in Pipes) {
            ctr += pipe.GetComponent<NewSnapper>().getSentSignal();
        }
        if (ctr == 27) {
            Debug.Log("Yippie!");
        }

        if(waterPipe.GetComponent<NewSnapper>().getSentSignal() == 1){
            Debug.Log("Yippey too!");
        }
    }
}

// PlugCount = GameController.GetComponent<GameControllerScript>().PlugCount;

