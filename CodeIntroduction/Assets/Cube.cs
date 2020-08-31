using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	
	public float sizeModifier = 2.5f;
	public string newName = "Cubey1337";
	public bool isRotated = false;

	// Used for initialization.
	void Start () {
		transform.name = ImproveName(newName);

		if (isRotated) {
			transform.localEulerAngles = Vector3.one * 45;
		}
	}

	// Called once per frame.
	void Update () {
		transform.localScale = Vector3.one * sizeModifier;
	}

	string ImproveName (string originalString) {
		return "-[" + originalString + "]-";
	}
}
