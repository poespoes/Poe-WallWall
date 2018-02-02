using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public float moveSpeed;
    public bool reverse;

    // Use this for initialization
    void Start () {
		if (reverse == true) {
            moveSpeed *= -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-moveSpeed, 0, 0);
    }

    // Wall bounce
    private void OnCollisionEnter2D(Collision2D collision) {
        if ((collision.gameObject.tag == "bounceMe")||(collision.gameObject.tag == "wallTop")
            ||(collision.gameObject.tag == "wallBottom")) {
            moveSpeed *= -1;

        }
    }
}
