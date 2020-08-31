using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public Camera gameCamera;
	public GameObject[] targets;
	public TextMesh scoreText;

	public int initialDifficulty = 3;

	private List<int> targetIds;
	private bool gettingReady;
	private int targetIndex;

	// Use this for initialization
	void Start () {
		InitializeGame ();
	}

	void InitializeGame () {
		targetIds = new List<int> ();

		for (int i = 0; i < initialDifficulty; i++) {
			targetIds.Add (Random.Range(0, 4));
		}

		gettingReady = true;

		StartCoroutine (AnimateSequence());
	}

	IEnumerator AnimateSequence () {
		yield return new WaitForSeconds (1.5f);

		for (int i = 0; i < targetIds.Count; i++) {
			int currentId = targetIds [i];

			targets[currentId].transform.localScale = Vector3.one * 0.5f;
			yield return new WaitForSeconds(1f);
			targets[currentId].transform.localScale = Vector3.one;
			yield return new WaitForSeconds(0.5f);
		}

		gettingReady = false;
	}

	IEnumerator AnimateTarget (GameObject target) {
		target.transform.localScale = Vector3.one * 0.5f;
		yield return new WaitForSeconds(1f);
		target.transform.localScale = Vector3.one;
		yield return new WaitForSeconds(0.5f);
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = "Score: " + (targetIds.Count - initialDifficulty);

		if (Input.GetKeyDown("space") || GvrPointerInputModule.Pointer.TriggerDown) {

			RaycastHit hit;

			if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit)) {

				if (gettingReady == false) {
					int hitTargetIndex = int.Parse(hit.transform.name);
					StartCoroutine (AnimateTarget (targets [hitTargetIndex]));

					if (hitTargetIndex == targetIds [targetIndex]) {
						targetIndex++;

						if (targetIndex >= targetIds.Count) {
							targetIndex = 0;
							targetIds.Add (Random.Range(0, 4));
							gettingReady = true;
							StartCoroutine (AnimateSequence());
						}
					} else {
						InitializeGame ();
					}
				}

			}
		}
	}
}
