using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public TextMesh infoText;
	public BeerCan[] beerCans;

	private float gameTimer = 0f;
	private float resetTimer = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool won = true;
		foreach (BeerCan can in beerCans) {
			if (can.wasHit == false) {
				won = false;
				break;
			}
		}

		if (won == false) {
			gameTimer += Time.deltaTime;
			infoText.text = "Shoot all the cans!\nTime: " + Mathf.Floor (gameTimer);
		} else {
			infoText.text = "You win! Your time: " + Mathf.Floor (gameTimer);

			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}
}
