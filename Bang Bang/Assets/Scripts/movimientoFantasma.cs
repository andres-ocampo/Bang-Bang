using UnityEngine;
using System.Collections;

public class movimientoFantasma : MonoBehaviour {

	// Use this for initialization

	public GameObject startPoint;
	public GameObject endPoint;

	public float velocidad;

	private bool haciaDer;

	void Start () {
		if (haciaDer) {
			transform.position = endPoint.transform.position;
		} else {
			transform.position = startPoint.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!haciaDer) {
			transform.position = Vector3.MoveTowards (transform.position, startPoint.transform.position, velocidad * Time.deltaTime);
			if(transform.position == startPoint.transform.position){
				haciaDer = true;
				GetComponent<SpriteRenderer> ().flipX = true;
 			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, endPoint.transform.position, velocidad * Time.deltaTime);
			if(transform.position == endPoint.transform.position){
				haciaDer = false;
				GetComponent<SpriteRenderer> ().flipX = false;
			}
		}
	}
}
