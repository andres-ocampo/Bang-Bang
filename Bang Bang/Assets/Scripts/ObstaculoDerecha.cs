﻿using UnityEngine;
using System.Collections;

public class ObstaculoDerecha : MonoBehaviour {
	// Use this for initialization
	Vector3 movimiento;
	float i = 0.1f;
	void Start () {

	}

	// Update is called once per frame
	void Update(){
		if (transform.position.x < 1){
			i = 0.1f;
		}
		else if (transform.position.x > 10){
			i = -0.1f;
		}
		movimiento = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
		transform.position = movimiento;
	}
}