using UnityEngine;
using System.Collections;

public class Choque : MonoBehaviour {
    AudioSource sonidoexplosion;
    public GameObject Explosion;
    public GameObject cañon;

    // Use this for initialization
    void Awake() {
        sonidoexplosion = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "cañonEnemigo") {
            GameObject cañonEnemigo = GameObject.FindGameObjectWithTag("cañonEnemigoPadre");
            Explosion = (GameObject)Instantiate(Explosion);
            Explosion.transform.position = cañon.transform.position;
            Destroy(cañonEnemigo);
            sonidoexplosion.PlayDelayed(0.5f);
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject,4);
        }
        
    }
}
