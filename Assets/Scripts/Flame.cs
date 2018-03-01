using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour {

    public float moveSpeed = 10f;


    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "deathZone") {
            Destroy(gameObject);
        }
    }
}