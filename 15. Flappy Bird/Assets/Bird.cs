using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public float speed = 3.5f;
	public float jumpForce = 10f;

	public bool dead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dead == true) {
			GetComponent<Rigidbody> ().useGravity = false;
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			return;
		}

		// Move forward
		GetComponent<Rigidbody>().velocity = new Vector3 (
			0,
			GetComponent<Rigidbody>().velocity.y,
			speed
		);

		// Make bird jump
		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown("space")) {
			GetComponent<Rigidbody>().velocity = new Vector3 (
				0,
				jumpForce,
				GetComponent<Rigidbody>().velocity.z
			);
		}
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.tag == "Obstacle") {
			dead = true;
		}
	}
}
