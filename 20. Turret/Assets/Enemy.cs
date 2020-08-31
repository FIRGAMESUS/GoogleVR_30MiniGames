using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int healthPoints = 5;

	public float speed = 1f;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * speed * Time.deltaTime;
	}

	public void OnHitBullet () {
		healthPoints--;

		if (healthPoints <= 0) {
			Destroy (gameObject);
		}
	}
}
