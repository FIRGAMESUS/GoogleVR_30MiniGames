using UnityEngine;
using System.Collections;

public class BeerCan : MonoBehaviour {

	public bool wasHit;
	public GameObject[] models;

	// Use this for initialization
	void Start () {
		int randomIndex = Random.Range (0, models.Length);
		for (int i = 0; i < models.Length; i++) {
			models [i].SetActive (i == randomIndex);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHit (float hitForce, Vector3 direction) {
		GetComponent<Rigidbody> ().AddForce (hitForce * direction);
		wasHit = true;
	}
}
