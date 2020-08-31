using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public Player player;
	public Ghost ghost;
	public TextMesh infoText;

	private float restartTimer = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		infoText.text = "Reach the treasure!\nLook away to stop moving!";

		if (ghost.centeredLook && player.moving) {
			player.spotted = true;
		}

		if (player.reachedTreasure) {
			infoText.text = "You won!";

			restartTimer -= Time.deltaTime;
			if (restartTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		} else if (player.spotted) {
			infoText.text = "You have been spotted :(";

			restartTimer -= Time.deltaTime;
			if (restartTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}
}
