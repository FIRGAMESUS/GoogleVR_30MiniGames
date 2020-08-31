using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public TextMesh infoText;
	public Player player;
	public PropContainer propContainer;

	private float gameTimer;
	private float restartTimer = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int propsRemaining = propContainer.amountOfProps - player.propsCollected;

		if (propsRemaining > 0) {
			gameTimer += Time.deltaTime;

			infoText.text = "Collect all the evidences!\nRemaining: " + propsRemaining;
		} else {
			infoText.text = "You got all the evidences!\nYour time: " + Mathf.Floor(gameTimer);

			restartTimer -= Time.deltaTime;
			if (restartTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}
}
