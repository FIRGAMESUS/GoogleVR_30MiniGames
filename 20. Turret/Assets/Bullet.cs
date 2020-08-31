using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Vector3 direction;
	private float speed;

	private bool shooting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (shooting == true) {
			transform.position += direction * speed * Time.deltaTime;
		}
	}

	public void Shoot (Vector3 shootingDirection, float bulletSpeed) {
		direction = shootingDirection;
		speed = bulletSpeed;

		shooting = true;
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.gameObject.GetComponent<Enemy> () != null) {
			Enemy enemy = otherCollider.gameObject.GetComponent<Enemy>();
			enemy.OnHitBullet ();

			Destroy (gameObject);
		}
	}
}
