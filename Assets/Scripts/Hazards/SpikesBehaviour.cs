using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour {
    
	public LayerMask Player;

	public int damage;
	public float force;
    
	void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag.Substring(0, 4) == "Gato")
        {
            col.gameObject.GetComponent<AllCatsBehaviour>().Hit(damage);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2)(col.transform.position - transform.position).normalized * force);
        }
	}
}
