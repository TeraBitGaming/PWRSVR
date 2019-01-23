using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    private int score;
    public GameObject money;
    // Start is called before the first frame update
    void Start() {
        score = PlayerPrefs.GetInt("usedEnergy");
    }

    // Update is called once per frame
    void Update() {
        if (score > 0) {
            Instantiate(money);
            score -= 10;
        }
    }
}
