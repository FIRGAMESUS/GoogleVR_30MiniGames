using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject sword;
	public float speed = 4.5f;
	public float walkingAmplitude = 0.25f;
	public float walkingFrequency = 2.0f;
	public float swordRange = 1.75f;
	public float swordCooldown = 0.25f;

	public bool isDead = false;
	public bool hasCrossedFinishLine = false;

	private float cooldownTimer;
	private Vector3 swordTargetPosition;

	// Use this for initialization
	void Start () {
		swordTargetPosition = sword.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			return;
		}

		transform.position += Vector3.forward * speed * Time.deltaTime;

        cooldownTimer -= Time.deltaTime;

		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown ("space")) {
			RaycastHit hit;

			if (cooldownTimer <= 0f && Physics.Raycast(transform.position, transform.forward, out hit)) {
				cooldownTimer = swordCooldown;

				if (hit.transform.GetComponent<Enemy> () != null && hit.transform.position.z - this.transform.position.z < swordRange) {
					Destroy (hit.transform.gameObject);
					swordTargetPosition = new Vector3 (-swordTargetPosition.x, swordTargetPosition.y, swordTargetPosition.z);
				}
			}
		}

		sword.transform.localPosition = Vector3.Lerp (sword.transform.localPosition, swordTargetPosition, Time.deltaTime * 15f);
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.GetComponent<Enemy> () != null) {
			isDead = true;
		} else if (collider.tag == "FinishLine") {
			hasCrossedFinishLine = true;
		}
	}
}
