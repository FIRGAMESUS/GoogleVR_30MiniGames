using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {

	public float verticalForce = 400f;
	public float horizontalForce = 150f;
	public float lifetime = 2f;

	// Use this for initialization
	void Start () {
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.AddForce (new Vector3(
			Random.Range(-horizontalForce, horizontalForce),
			verticalForce,
			0
		));
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0f) {
			Destroy (gameObject);
		}
	}
}
