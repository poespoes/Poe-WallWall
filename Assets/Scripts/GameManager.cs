using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public int score = 0;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			instance.score = 0;

			Destroy(gameObject); // THERE CAN BE ONLY ONE!
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
