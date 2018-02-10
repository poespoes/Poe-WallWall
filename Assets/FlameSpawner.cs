using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSpawner : MonoBehaviour {

    public GameObject flamePrefab;
    private float timer = 0;
    public float spawnInterval = 2;

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if(timer >= spawnInterval) {
            GameObject newProjectileObj = Instantiate(flamePrefab);
            newProjectileObj.transform.position = transform.position;
            timer = 0;
        }
    }
}