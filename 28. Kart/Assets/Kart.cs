using UnityEngine;
using System.Collections;

public class Kart : MonoBehaviour {

    public GameObject player;
	public float speed = 0.25f;
	public GameObject kartModel;

	private int currentCheckpoint;
	private int currentLap;

	public int CurrentLap { get { return currentLap; } }

	// Use this for initialization
	void Start () {
		currentCheckpoint = -1;
		currentLap = 0;
	}
	
	// Update is called once per frame
	void Update () {
		kartModel.transform.eulerAngles = new Vector3 (
			-90,
			kartModel.transform.eulerAngles.y,
			kartModel.transform.eulerAngles.z
		);

		Vector3 movementDirection = new Vector3 (
			transform.forward.x,
			0,
			transform.forward.z
		);
		player.transform.position += movementDirection.normalized * speed * Time.deltaTime;
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.tag == "Checkpoint") {
			int checkpoint = int.Parse(otherCollider.name);

			if (checkpoint == currentCheckpoint + 1) {
				currentCheckpoint++;

				Debug.Log ("Checkpoint: " + currentCheckpoint);
			}

			if (checkpoint == 0 && currentCheckpoint == 3) {
				currentCheckpoint = 0;
				currentLap++;
				Debug.Log ("New lap!");
			}
		}
	}
}
