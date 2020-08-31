using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cubePrefab;
	public int cubeAmount = 10;
	public float randomArea = 10f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < cubeAmount; i++) {
			GameObject cubeObject = Instantiate (cubePrefab);
			cubeObject.transform.position = new Vector3 (
				Random.Range(-randomArea, randomArea),
				Random.Range(-randomArea, randomArea),
				0
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
