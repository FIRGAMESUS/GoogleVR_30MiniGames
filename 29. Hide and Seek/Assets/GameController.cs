using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Camera gameCamera;
	public GameObject target;
	public float stareDuration = 1f;
	public float targetDistance = 5f;
	public TextMesh infoText;
	public float gameDuration = 10f;

	private float stareTimer;
	private int hits;
	private float gameTimer;

	// Use this for initialization
	void Start () {
		stareTimer = 0f;
		gameTimer = 10f;

		MoveCube ();
	}
	
	// Update is called once per frame
	void Update () {
	
		RaycastHit hit;

		if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit)) {
			if (hit.transform.name == "Target") {
				stareTimer += Time.deltaTime;
			} else {
				stareTimer = 0f;
			}
		}

		// Check if it's time to teleport the target

		if (stareTimer >= stareDuration && gameTimer >= 0f) {
			stareTimer = 0f;

			hits++;

			MoveCube ();
		}

		gameTimer -= Time.deltaTime;

		if (gameTimer >= 0f) {
			infoText.text = "Hits: " + hits;
			infoText.text += "\nTimer: " + Mathf.Floor (gameTimer);
		} else {
			infoText.text = "Game over!\nYour score: " + hits;

			if (gameTimer < -4f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}

	void MoveCube () {
		float randomAngle = Random.Range (0, 2 * Mathf.PI);
		target.transform.position = new Vector3 (
			Mathf.Cos(randomAngle) * targetDistance,
			Random.Range(0, targetDistance),
			Mathf.Sin(randomAngle) * targetDistance
		);
	}
}
