using UnityEngine;
using System.Collections;

using System;

using Random = UnityEngine.Random;

public class Target : MonoBehaviour {

	public float minimumHorizontalForce;
	public float minimumVerticalForce;
	public float maximumHorizontalForce;
	public float maximumVerticalForce;

	public Action onHitFloor;

	// Use this for initialization
	void Start () {

		int throwDirection = 1;

		if (transform.position.x > 0) {
			throwDirection = -1;
		}

		GetComponent<Rigidbody> ().AddForce (new Vector3(
			Random.Range(minimumHorizontalForce, maximumHorizontalForce) * throwDirection,
			Random.Range(minimumVerticalForce, maximumVerticalForce),
			0
		));
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (transform.position + GetComponent<Rigidbody>().velocity);
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.GetComponent<Bullet> () != null) {
			Destroy (this.gameObject);
			Destroy (otherCollider.gameObject);
		}

		if (otherCollider.transform.name == "Floor") {
			if (onHitFloor != null) {
				onHitFloor ();
			}
		}
	}
}
