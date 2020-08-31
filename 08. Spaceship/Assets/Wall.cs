using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public Ship ship;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    
	void Update () {
		transform.position = new Vector3 (
			transform.position.x,
			transform.position.y,
			ship.transform.position.z
		);
	}
}
