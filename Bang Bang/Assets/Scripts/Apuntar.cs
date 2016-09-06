using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Apuntar : MonoBehaviour {
    Vector3 mousePos;
    Vector3 objectPos;
    public Text angulo;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        mousePos = Input.mousePosition;
        mousePos.z = 0f;

        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-20));
        angulo.text = (Mathf.Ceil(angle)).ToString();
    }
}
