using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndText : MonoBehaviour {

    Text _myText;

    // Use this for initialization
    void Start () {
        _myText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        _myText.text = "You took " + GameManager.instance.score + " secs!" + "    Best Time:" + GameManager.instance.highScore + " secs!";

        if (Input.GetKeyDown(KeyCode.R)) {
            GameManager.instance.score = 0;
            SceneManager.LoadScene("Main");
        }
    }
}
