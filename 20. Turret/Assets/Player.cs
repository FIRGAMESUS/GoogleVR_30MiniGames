using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject bulletPrefab;
	public float bulletSpeed = 4.2f;
	public float shootingSpeed = 0.25f;
	public float powerupSpeed = 0.10f;

	public float powerupCooldown = 5f;
	public float powerupDuration = 3f;

	public bool dead;

	private float shootingTimer;
	private float powerupTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dead == true) {
			return;
		}

		powerupTimer -= Time.deltaTime;
		if (GvrPointerInputModule.Pointer.TriggerDown == true || Input.GetKeyDown("space")) {
			if (powerupTimer < -powerupCooldown) {
				powerupTimer = powerupDuration;
			}
		}

		shootingTimer -= Time.deltaTime;
		if (shootingTimer <= 0f) {
			shootingTimer = shootingSpeed;

			if (powerupTimer > 0f) {
				shootingTimer = powerupSpeed;
			}

			GameObject bulletObject = Instantiate(bulletPrefab);
			bulletObject.transform.position = this.transform.position;

			Bullet bullet = bulletObject.GetComponent<Bullet> ();
			bullet.Shoot (transform.forward, bulletSpeed);
		}
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.gameObject.GetComponent<Enemy> () != null) {
			dead = true;
		}
	}
}
