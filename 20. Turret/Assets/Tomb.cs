using UnityEngine;
using System.Collections;

public class Tomb : MonoBehaviour {

	public GameObject[] models;
	public float spawnTimer;
	public float spawnInterval = 4f;

	public bool Ready {
		get {
			return spawnTimer <= 0f;
		}
	}

	// Use this for initialization
	void Start () {
		spawnTimer = spawnInterval;

		int randomIndex = Random.Range (0, models.Length);
		for (int i = 0; i < models.Length; i++) {
			models [i].SetActive (i == randomIndex);
		}

		transform.localEulerAngles = new Vector3 (0, Random.Range (0, 360), 0);
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
	}

	public void ResetTimer () {
		spawnTimer = spawnInterval;
	}
}
