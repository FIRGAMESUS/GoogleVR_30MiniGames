using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	private float lifetime = 10f;

	// Use this for initialization
	void Start () {
		transform.localEulerAngles = new Vector3 (
			Random.Range(0, 360),
			Random.Range(0, 360),
			Random.Range(0, 360)
		);
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;

		if (lifetime < 0) {
			Destroy (gameObject);
		}
	}
}
