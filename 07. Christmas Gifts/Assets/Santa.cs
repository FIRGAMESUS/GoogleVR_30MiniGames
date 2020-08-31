using UnityEngine;
using System.Collections;
using System;

public class Santa : MonoBehaviour {

	public float speed = 3.5f;
	public float throwingForce = 300f;
	public GameObject giftPrefab;
	public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Make Santa move.
		transform.position += Vector3.forward * speed * Time.deltaTime;

		// Throwing gifts.
		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown("space")) {
			GameObject giftObject = Instantiate (giftPrefab);
			giftObject.transform.position = this.transform.position;
			giftObject.GetComponent<Rigidbody> ().AddForce (this.transform.forward * throwingForce);

			Gift gift = giftObject.GetComponent<Gift> ();
			gift.onHitHouse = () => {
				score += 100;
			};
		}
	}
}
