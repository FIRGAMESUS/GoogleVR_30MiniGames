using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public TextMesh infoText;
	public Player player;
	public Transform enemyContainer;

	private float restartTimer = 3f;

	// Use this for initialization
	void Start () {
		infoText.text = "Find the button and\nenter the castle!";
	}
	
	// Update is called once per frame
	void Update () {
		if (player.enteredCastle) {
			int enemiesRemaining = enemyContainer.GetComponentsInChildren<Enemy> ().Length;

			if (enemiesRemaining > 0) {
				infoText.text = "Destroy all the enemies!";
				infoText.text += "\nEnemies remaining: " + enemiesRemaining;
			} else {
				infoText.text = "You win!";

				restartTimer -= Time.deltaTime;
				if (restartTimer <= 0f) {
					SceneManager.LoadScene (SceneManager.GetActiveScene().name);
				}
			}
		}
	}
}
