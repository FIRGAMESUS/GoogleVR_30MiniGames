using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit)) {
			if (hit.transform.GetComponent<Fruit> () != null) {
				score += 100;
				Destroy (hit.transform.gameObject);
			}
		}
	}
}
