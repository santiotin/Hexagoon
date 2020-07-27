using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f;
    public GameObject gameManager;
    public GameObject hexagonPrefab;
    float nextTimeToSpawn = 0f;
    int numHexa = 0;
    bool generate = false;

    // Update is called once per frame
    void Update() {

        if(generate) {
            if(Time.time >= nextTimeToSpawn) {
                GameObject hexa = Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
                hexa.GetComponent<HexaMov>().setRotationSpeed(getSpeed());

                nextTimeToSpawn = Time.time + 1f / spawnRate;
                numHexa++;
            }
        }
    }

    float getSpeed() {
        if(numHexa < 30) return 0.0f;
        else {
            float x = Random.Range(-1.0f,1.0f);
            if(x > 0) return 0.5f;
            else return -0.5f;
        }
    }

    public void generateHexa(bool g) {
        generate = g;
    }
}
