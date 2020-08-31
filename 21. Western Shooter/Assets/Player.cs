using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown("space")) {
			RaycastHit hit;

			if (Physics.Raycast (transform.position, transform.forward, out hit)) {
				if (hit.transform.GetComponent<BeerCan> () != null) {
					hit.transform.GetComponent<BeerCan> ().OnHit (700, transform.forward);
				}
			}
		}
	}
}
