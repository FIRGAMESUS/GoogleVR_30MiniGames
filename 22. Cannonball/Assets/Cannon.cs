using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public float shootingForce = 5.2f;
	public GameObject cannonballPrefab;
	public int shotsFired = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown("space")) {
			GameObject cannonballObject = Instantiate(cannonballPrefab);
			cannonballObject.transform.position = transform.position;
			cannonballObject.GetComponent<Rigidbody>().AddForce(transform.forward * shootingForce);

			shotsFired++;
		}
	}
}
