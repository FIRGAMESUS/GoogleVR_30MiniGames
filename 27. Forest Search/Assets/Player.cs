using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int propsCollected = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown("space")) {
			RaycastHit hit;

			if (Physics.Raycast(transform.position, transform.forward, out hit)) {
				if (hit.transform.tag == "TargetProp") {
					Destroy (hit.transform.gameObject);
					propsCollected++;
				}
			}
		}
	}
}
