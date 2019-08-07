﻿using UnityEngine;
using System.Collections;

public class carSpawner : MonoBehaviour {
	public GameObject[] cars;
	int carNo;
	public float maxPos = 2.0f;
	public float delayTimer = 0.5f;
	float timer;

	// Use this for initialization
	void Start () {
		timer = delayTimer;


	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 carPos = new Vector3(Random.Range(-2.0f,2.0f),transform.position.y,transform.position.z);
			carNo = Random.Range(0,5);
			Instantiate (cars[carNo], carPos, transform.rotation);
			timer = delayTimer;

		} 
	}
}
