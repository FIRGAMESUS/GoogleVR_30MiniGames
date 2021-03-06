﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health = 100;
	public GameObject bulletPrefab;

	public float shootingCooldown = 0.1f;
	public float meleeCooldown = 0.5f;

	private float shootingTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		shootingTimer -= Time.deltaTime;

		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown("space")) {
			if (shootingTimer <= 0f) {
				shootingTimer = shootingCooldown;

				Collider[] colliders = Physics.OverlapSphere (transform.position, 1f);

				bool meleeAttack = false;
				Enemy meleeEnemy = null;
				foreach (Collider collider in colliders) {
					if (collider.GetComponent<Enemy> () != null) {
						meleeAttack = true;
						meleeEnemy = collider.GetComponent<Enemy> ();
						break;
					}
				}

				if (meleeAttack == false) {
					GameObject bulletObject = Instantiate (bulletPrefab);
					bulletObject.transform.position = this.transform.position;

					Bullet bullet = bulletObject.GetComponent<Bullet> ();
					bullet.direction = transform.forward;
				} else {
					shootingTimer = meleeCooldown;
					Destroy (meleeEnemy.gameObject);
				}
			}
		}
	}
}
