using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour {

	public int health = 3;
	public float rotatingSpeed = 15f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localEulerAngles = new Vector3 (
			0,
			transform.localEulerAngles.y + rotatingSpeed * Time.deltaTime,
			0
		);
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.GetComponent<Bullet> () != null) {
			health--;

			Destroy (otherCollider.gameObject);

			if (health == 0) {
				Destroy (gameObject);
			}
		} else if (otherCollider.GetComponent<Ship> () != null) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}
}
