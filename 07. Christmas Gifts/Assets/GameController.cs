using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Santa santa;
	public TextMesh infoText;
	public float gameTimer = 20f;

	private float restartTimer = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameTimer -= Time.deltaTime;

		infoText.text = "Score: " + santa.score;
		infoText.text += "\nTime left: " + Mathf.Floor(gameTimer);

		if (gameTimer <= 0f) {
			infoText.text = "Game over!\nYour final score: " + santa.score;

			restartTimer -= Time.deltaTime;
			if (restartTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}
}
