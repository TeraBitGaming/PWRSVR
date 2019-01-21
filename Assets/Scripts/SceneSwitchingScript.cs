using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchingScript : MonoBehaviour{
    private Light ballLight;
    private bool shineBrighter;

    public void endScene() {
        shineBrighter = true;
    }

    void Start() {
        ballLight = GameObject.FindGameObjectWithTag("Sphere").GetComponent<Light>();
    }

    void Update() {
        if (shineBrighter == true) {
            if (ballLight.intensity < 20) {
                ballLight.intensity += 0.1f;
            }
            if (ballLight.intensity >= 19.99) {
                SceneManager.LoadScene("FinalScreenScene");
            }
        }
    }
}