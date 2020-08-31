using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Player player;
	public GameObject enemyPrefab;
	public GameObject tombPrefab;
	public float spawnRadius = 10f;
	public float spawnInterval = 5f;

	public TextMesh infoText;

	private float spawnTimer;
	private float gameTimer;
	private float gameOverTimer = 3f;
	private List<Tomb> tombs;

	// Use this for initialization
	void Start () {
		tombs = new List<Tomb> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.dead == false) {
			gameTimer += Time.deltaTime;
			infoText.text = "Score: " + Mathf.FloorToInt (gameTimer);
		} else {
			infoText.text = "Game over :(\nFinal score: " + Mathf.FloorToInt (gameTimer);

			gameOverTimer -= Time.deltaTime;
			if (gameOverTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}

		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0f) {
			spawnTimer = spawnInterval;

			GameObject tombObject = Instantiate (tombPrefab);
			float randomAngle = Random.Range (0f, 2 * Mathf.PI);
			tombObject.transform.position = new Vector3 (
				player.transform.position.x + Mathf.Cos(randomAngle) * spawnRadius,
				0,
				player.transform.position.z + Mathf.Sin(randomAngle) * spawnRadius
			);

			Tomb tomb = tombObject.transform.GetComponent<Tomb> ();
			tombs.Add (tomb);
		}

		foreach (Tomb tomb in tombs) {
			if (tomb.Ready) {
				tomb.ResetTimer ();

				GameObject enemyObject = Instantiate (enemyPrefab);
				enemyObject.transform.position = tomb.transform.position;

				Enemy enemy = enemyObject.GetComponent<Enemy> ();
				enemy.transform.LookAt (player.transform.position);
				enemy.direction = (player.transform.position - enemy.transform.position).normalized;
			}
		}
	}
}
