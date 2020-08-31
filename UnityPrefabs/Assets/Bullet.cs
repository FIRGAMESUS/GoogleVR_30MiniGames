using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float shootingForce = 10f;
	public Vector3 shootingDirection;
	public GameObject explosionPrefab;

	public float lifetime = 3f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (shootingDirection * shootingForce);
	}

	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.transform.tag == "TriggerExplosion") {
			GameObject explosionObject = Instantiate (explosionPrefab);
			explosionObject.transform.position = transform.position;
		}
	}
}
