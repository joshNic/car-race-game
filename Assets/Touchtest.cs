using UnityEngine;
using System.Collections;

public class Touchtest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {

			Debug.Log(Input.GetTouch(0).position);
		
		}
	
	}
}
