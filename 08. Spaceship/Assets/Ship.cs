using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour {

    public GameObject player;
	public float speed = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player.transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.tag == "Obstacle") {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}
}
