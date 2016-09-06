using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Disparo : MonoBehaviour {

    float Velocidad;
    Rigidbody2D bala;
    SpringJoint2D union;
    Vector3 mousePos;
    Vector3 objectPos;
    public Text texto;
    public GameObject sonido;
    public GameObject cañon;
    float Angulo;
    // Use this for initialization
    void Start () {
        bala = GetComponent<Rigidbody2D>();
        union = GetComponent<SpringJoint2D>();
        sonido = GameObject.FindGameObjectWithTag("audio_canon");
        cañon= GameObject.FindGameObjectWithTag("canon");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string potencia = texto.text;
        Velocidad = float.Parse(potencia);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sonido.GetComponent<AudioSource>().Play();
            Destroy(union);
            mousePos = Input.mousePosition;
            mousePos.z = 0f;

            objectPos = Camera.main.WorldToScreenPoint(cañon.transform.position);  
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            Angulo = Mathf.Atan2(mousePos.y, mousePos.x);
            Vector2 fuerza = new Vector2(Velocidad * Mathf.Cos(Angulo), Velocidad * Mathf.Sin(Angulo));
            bala.AddForce(fuerza);  
        }
    }
}
