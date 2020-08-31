using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public float gravityValue = 9.8f;

	public TextMesh infoText;
	public GameObject targetPrefab;
	public Cannon cannon;
	public int targetAmount = 5;
	public int availableShots = 10;
	public float minimumTargetDistance = 5f;
	public float maximumTargetDistance = 15f;

	private float gameOverTimer = 3f;

	// Use this for initialization
	void Start () {
		Physics.gravity = Vector3.down * gravityValue;

		for (int i = 0; i < targetAmount; i++) {
			GameObject targetObject = Instantiate (targetPrefab);
			targetObject.transform.SetParent (transform);

			float randomAngle = Random.Range (0f, 2 * Mathf.PI);

			targetObject.transform.position = new Vector3 (
				Mathf.Cos(randomAngle) * Random.Range(minimumTargetDistance, maximumTargetDistance),
				0,
				Mathf.Sin(randomAngle) * Random.Range(minimumTargetDistance, maximumTargetDistance)
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		int remainingShots = availableShots - cannon.shotsFired;
		int remainingTargets = transform.GetComponentsInChildren<Orb>().Length;

		if (remainingShots <= 0) {
			infoText.text = "Game over!";
		} else {
			infoText.text = "Destroy all the orbs!";
			infoText.text += "\nShots fired: " + remainingShots;
			infoText.text += "\nOrbs remaining: " + remainingTargets;
		}

		if (remainingTargets == 0) {
			infoText.text = "You win!";
		}

		if (remainingShots <= 0 || remainingTargets == 0) {
			gameOverTimer -= Time.deltaTime;

			if (gameOverTimer <= 0f) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
}
