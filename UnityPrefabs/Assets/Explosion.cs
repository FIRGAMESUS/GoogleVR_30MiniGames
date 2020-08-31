using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public GameObject[] particlePrefabs;
	public int amountOfParticles = 3;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < amountOfParticles; i++) {
			GameObject particlePrefab = Instantiate (particlePrefabs[Random.Range(0, particlePrefabs.Length)]);
			particlePrefab.transform.position = transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
