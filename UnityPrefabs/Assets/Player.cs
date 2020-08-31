using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			GameObject bulletObject = Instantiate (bulletPrefab);
			Bullet bullet = bulletObject.GetComponent<Bullet> ();

			Vector3 shootingDirection = new Vector3(
				Random.Range(-0.15f, 0.15f),
				Random.Range(-0.1f, 0.1f),
				1
			);

			bullet.shootingDirection = shootingDirection.normalized;
		}
	}
}
