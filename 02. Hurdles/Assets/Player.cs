using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maximumSpeed = 5.5f;
	public float acceleration = 1f;
	public float jumpingForce = 450f;
	public float jumpingCooldown = 0.6f;

	public bool reachedFinishLine = false;

	private float speed = 0f;
	private float jumpingTimer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// Move the player forward.
		speed += acceleration * Time.deltaTime;
		if (speed > maximumSpeed) {
			speed = maximumSpeed;
		}
		transform.position += speed * Vector3.forward * Time.deltaTime;

		// Make the player jump.
		jumpingTimer -= Time.deltaTime;
		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown("space")) {
			if (jumpingTimer <= 0f) {
				jumpingTimer = jumpingCooldown;
				this.GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpingForce);
			}
		}
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.tag == "Obstacle") {
			speed *= 0.3f;
		}

		if (collider.tag == "FinishLine") {
			reachedFinishLine = true;
		}
	}
}
