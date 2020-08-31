using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Ship ship;
	public GameObject asteroidPrefab;
	public TextMesh infoText;
	public int asteroidAmount = 10;
	public float spawnDistance = 20f;

	private float gameTimer;
	private float gameOverTimer = 3f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < asteroidAmount; i++) {
			GameObject asteroidObject = Instantiate (asteroidPrefab);

			asteroidObject.transform.SetParent (transform);

			float randomAngle = Random.Range (0, 2 * Mathf.PI);
			float randomHeightAngle = Random.Range (0, 2 * Mathf.PI);

			asteroidObject.transform.position = new Vector3 (
				Mathf.Cos(randomAngle) * spawnDistance,
				Mathf.Cos(randomHeightAngle) * spawnDistance,
				Mathf.Sin(randomAngle) * spawnDistance
			);
		}
	}
	
	// Update is called once per frame
	void Update () {

		int remainingAsteroids = transform.GetComponentsInChildren<Asteroid> ().Length;
		bool isGameOver = (remainingAsteroids == 0);

		if (isGameOver == false) { 
			gameTimer += Time.deltaTime;

			infoText.text = "Game time: " + Mathf.Floor (gameTimer);
		} else {
			infoText.text = "You win!\nYour time:" + Mathf.Floor (gameTimer);

			gameOverTimer -= Time.deltaTime;
			if (gameOverTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}
}
