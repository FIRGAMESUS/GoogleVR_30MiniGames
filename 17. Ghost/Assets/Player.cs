using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 4.5f;
	public bool moving = false;
	public bool spotted = false;
	public bool reachedTreasure = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			if (hit.transform.tag == "LookingArea") {
				moving = true;
			} else {
				moving = false;
			}
		} else {
			moving = false;
		}

		if (moving && !reachedTreasure && !spotted) {
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.tag == "Treasure") {
			reachedTreasure = true;
		}
	}
}
