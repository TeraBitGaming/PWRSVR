using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    private int PlugCount = 0;
    public GameObject light1;
    public GameObject light2;
    public GameObject plug1;
    public GameObject Plug2;
    public GameObject Plug3;
    public GameObject[] pipes;
    public GameObject waterPipe;
    private GameObject kettle;
    public GameObject energyBar;
    public GameObject key;
    public GameObject door;
    public GameObject water;
    private int energyUsed;
    private AudioSource auS;
    public AudioClip energyOn;

    public void recordEnergyUsed() {
        PlayerPrefs.SetInt("usedEnergy", energyUsed);
    }

    void Start() {
        pipes = GameObject.FindGameObjectsWithTag("Pipe");
        kettle = GameObject.FindGameObjectWithTag("Kettle");
        auS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        PlugCount = plug1.GetComponent<NewSnapper>().getSentSignal() + Plug2.GetComponent<NewSnapper>().getSentSignal() + Plug3.GetComponent<NewSnapper>().getSentSignal();
        if (PlugCount == 3){
            light1.GetComponent<Light>().enabled = true;
            light2.GetComponent<Light>().enabled = true;
            if (energyBar.transform.localScale.z > 0) {
                energyBar.transform.localScale -= new Vector3(0, 0, 0.001f);
                energyUsed += 1;
            }
        } else if (PlugCount < 3){
            light1.GetComponent<Light>().enabled = false;
            light2.GetComponent<Light>().enabled = false;
        }

        if (PlugCount == 3 && energyUsed == 1) {
            auS.PlayOneShot(energyOn);
        }

        if(waterPipe.GetComponent<NewSnapper>().getSentSignal() == 1){
            kettle.GetComponent<WaterJugScript>().full = true;
            water.SetActive(true);
            water.GetComponent<ParticleSystem>().Play();
        } else {
            kettle.GetComponent<WaterJugScript>().full = false;
            water.SetActive(false);
        }
        if (key.GetComponent<NewSnapper>().getSentSignal() == 1){
            door.GetComponent<HingeJoint>().useMotor= true;
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.tag == "Kettle" || other.tag == "Water" || other.tag == "Steam"){
            int ctr = 0;
            foreach (GameObject pipe in pipes) {
                ctr += pipe.GetComponent<NewSnapper>().getSentSignal();
            }
            if (ctr == 27) {
                kettle.GetComponent<WaterJugScript>().heating = true;
                if (energyBar.transform.localScale.z > 0) {
                    energyBar.transform.localScale -= new Vector3(0, 0, 0.0015f);
                    energyUsed += 1;
                }
            } else {
                kettle.GetComponent<WaterJugScript>().heating = false;
            }
        }
    }
}

// PlugCount = GameController.GetComponent<GameControllerScript>().PlugCount;

