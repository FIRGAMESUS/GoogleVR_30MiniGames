﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0.5f;
	public Vector3 castlePosition;
	public bool enteredCastle;

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Looking at the door
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit)) {
			if (hit.transform.GetComponent<DoorButton> () != null) {
				hit.transform.GetComponent<DoorButton> ().OnLook ();
				MoveToCastle ();
			}
		}

		// Shooting at enemies
		if (/*GvrViewer.Instance.Triggered ||*/ Input.GetKeyDown ("space")) {
			RaycastHit enemyHit;
			if (Physics.Raycast (transform.position, transform.forward, out enemyHit)) {
				if (hit.transform.GetComponent<Enemy> () != null) {
					Destroy (hit.transform.gameObject);
				}
			}
		}

		// Moving logic
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * speed);
	}

	private void MoveToCastle () {
		enteredCastle = true;
		targetPosition = castlePosition;
	}
}
