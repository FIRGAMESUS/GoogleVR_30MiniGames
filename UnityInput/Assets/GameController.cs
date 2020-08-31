using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] gameCameras;

	private int gameCameraIndex = 0;

	// Use this for initialization
	void Start () {
		FocusOnCamera (gameCameraIndex);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ChangeCamera (1);
		}

		if (Input.GetMouseButtonDown (1)) {
			ChangeCamera (-1);
		}
	}

	void FocusOnCamera (int index) {
		for (int i = 0; i < gameCameras.Length; i++) {
			gameCameras [i].SetActive (i == index);
		}
	}

	void ChangeCamera (int direction) {
		gameCameraIndex += direction;

		if (gameCameraIndex >= gameCameras.Length) {
			gameCameraIndex = 0;
		}

		if (gameCameraIndex < 0) {
			gameCameraIndex = gameCameras.Length - 1;
		}

		FocusOnCamera (gameCameraIndex);
	}
}
