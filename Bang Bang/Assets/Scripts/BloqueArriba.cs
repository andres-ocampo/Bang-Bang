using UnityEngine;
using System.Collections;

public class BloqueArriba : MonoBehaviour {
	// Use this for initialization
	Vector3 movimiento;
	float i = -0.1f;
	void Start () {

	}

	// Update is called once per frame
	void Update(){
		if (transform.position.y < 1){
			i = 0.1f;
		}
		else if (transform.position.y > 6){
			i = -0.1f;
		}
		movimiento = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);
		transform.position = movimiento;
	}
}