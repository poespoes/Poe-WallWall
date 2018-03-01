using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject wallHorizontalPrefab;
    public GameObject wallVerticalPrefab;
    public GameObject endFlagPrefab;
    public float tileWidth = 2f;
    public float tileHeight = 2f;
    public string levelFile = "level1.txt";

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

        //LEVEL BUILDER
        // Reading the file into string.
        string levelString = File.ReadAllText(Application.dataPath + Path.DirectorySeparatorChar + levelFile);

        // Splitting the string into lines.
        string[] levelLines = levelString.Split('\n');
        int width = 0;
        // Iterating over the lines.
        for (int row = 0; row < levelLines.Length; row++) {
            string currentLine = levelLines[row];
            width = currentLine.Length;
            // Iterating over all the chars in a line.
            for (int col = 0; col < currentLine.Length; col++) {
                char currentChar = currentLine[col];
                if (currentChar == 'x') {
                    // Make a wall!
                    GameObject wallObj = Instantiate(wallHorizontalPrefab);
                    wallObj.transform.parent = transform;
                    wallObj.transform.position = new Vector3(col * tileWidth, -row * tileHeight, 0);
                } else if (currentChar == 'p') {
                    // Make the player!
                    GameObject playerObj = Instantiate(playerPrefab);
                    playerObj.transform.parent = transform;
                    playerObj.transform.position = new Vector3(col * tileWidth, -row * tileHeight, 0);
                } else if (currentChar == 'f') {
                    // Make the player!
                    GameObject playerObj = Instantiate(endFlagPrefab);
                    playerObj.transform.parent = transform;
                    playerObj.transform.position = new Vector3(col * tileWidth, -row * tileHeight, 0);
                } else if (currentChar == 'w') {
                    // We flip a coin
                    //if (Random.value <= 0.5f) {
                        GameObject enemyObj = Instantiate(wallVerticalPrefab);
                        enemyObj.transform.parent = transform;
                        enemyObj.transform.position = new Vector3(col * tileWidth, -row * tileHeight, 0);
                    //}
                }
            }
        }

        float myX = -(width * tileWidth) / 2f + tileWidth / 2f;
        float myY = (levelLines.Length * tileHeight) / 2f - tileHeight / 2f;
        transform.position = new Vector3(myX, myY, 0);
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
