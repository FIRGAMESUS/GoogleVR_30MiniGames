using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public float speed = 4.5f;
	public float shootingCooldown = 0.5f;
	public GameObject bulletPrefab;
	public GameObject bulletOrigin;

	private float shootingTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Decrease shooting timer
		shootingTimer -= Time.deltaTime;

		// Movement logic
		transform.position += transform.forward * speed * Time.deltaTime;

		// Aiming logic
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit)) {
			if (hit.transform.tag == "Target" && shootingTimer <= 0f) {
				shootingTimer = shootingCooldown;

				GameObject bulletObject = Instantiate (bulletPrefab);
				bulletObject.transform.position = bulletOrigin.transform.position;

				Bullet bullet = bulletObject.GetComponent<Bullet> ();
				bullet.direction = (hit.transform.position - bulletObject.transform.position).normalized;
			}
		}
	}
}
