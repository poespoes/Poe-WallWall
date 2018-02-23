using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public int score = 0;
    public int highScore = 0;

    public bool firstGame = true;

	// Use this for initialization
	void Start () {
        if (firstGame == true) {
            highScore = 15;
            firstGame = false;
        }

		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			//instance.score = 0;

			Destroy(gameObject); // THERE CAN BE ONLY ONE!
            return; // Ensure we leave start if we're destroying ourself (Destroy actually just marks us as "to be destroyed soon").
        }

        // Here's the normal file version
        string fullFilePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "SaveData.txt";
        if (File.Exists(fullFilePath)) {
            string highScoreString = File.ReadAllText(fullFilePath);
            highScore = int.Parse(highScoreString);
        }

    }

    public void endGame() {
        // When the score is faster/less than our previous best, record a new high score.
        if (score < highScore) {
            highScore = score;

            string fullFilePath = Application.dataPath + Path.DirectorySeparatorChar + "SaveData.txt";
            File.WriteAllText(fullFilePath, highScore.ToString());
        }
        SceneManager.LoadScene("End");
    }

    // Update is called once per frame
    void Update () {
		
	}


}
