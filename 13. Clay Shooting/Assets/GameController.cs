using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

using System;

using Random = UnityEngine.Random;

public class GameController : MonoBehaviour {

	public GameObject targetPrefab;
	public TextMesh scoreText;

	private float targetInterval = 1f;
	private int targetsToShoot = 1;
	private bool isGameOver = false;

	private float restartTimer = 3f;

	// Use this for initialization
	void Start () {
		StartCoroutine (ShootingRoutine ());
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver == false) {
			scoreText.text = "Level: " + targetsToShoot;
		} else {
			scoreText.text = "Game over!\nYour score: " + targetsToShoot;

			restartTimer -= Time.deltaTime;
			if (restartTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}

	private IEnumerator ShootingRoutine () {
		for (int i = 0; i < targetsToShoot; i++) {
			SpawnTarget ();

			yield return new WaitForSeconds (targetInterval);
		}

		yield return new WaitForSeconds (3f);

		if (isGameOver == false) {
			targetsToShoot++;

			StartCoroutine (ShootingRoutine ());
		}
	}

	void SpawnTarget () {
		GameObject targetObject = Instantiate (targetPrefab);
		targetObject.transform.position = new Vector3 (
			Random.Range(0f, 1f) > 0.5f ? -5 : 5,
			2,
			7
		);

		Target target = targetObject.GetComponent<Target> ();
		target.onHitFloor = () => {
			isGameOver = true;
		};
	}
}
