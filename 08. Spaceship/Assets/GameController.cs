using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Ship ship;
    public GameObject Player;
	public GameObject[] asteroidPrefabs;
	public TextMesh scoreText;

	public float spawnDistance = 5f;
	public float spawnIncrement = 1f;

	private float spawnPointer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ship.transform.position.z > spawnPointer) {
			GameObject asteroidPrefab = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
			GameObject asteroidObject = Instantiate (asteroidPrefab);

			asteroidObject.transform.position = new Vector3 (
				Random.Range(-2.3f, 2.3f),
				Random.Range(-2.3f, 2.3f),
                Player.transform.position.z + spawnDistance
			);

			spawnPointer = Player.transform.position.z + spawnIncrement;
		}

		int playerScore = Mathf.RoundToInt (Player.transform.position.z);
		if (playerScore < 0) {
			playerScore = 0;
		}
		scoreText.text = "Score: " + playerScore;
	}
}
