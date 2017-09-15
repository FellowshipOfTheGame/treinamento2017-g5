using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour {

	private Rigidbody2D Rigid;

	private int damage;
	private float force;
	private float speed;

	// Use this for initialization
	void Start () {
		Rigid = GetComponent<Rigidbody2D> ();
		//speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Rigid.velocity = new Vector2 (transform.right.x * speed, Rigid.velocity.y);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag.Substring(0,4) == "Gato") {
            col.gameObject.GetComponent<AllCatsBehaviour>().Hit(damage);
			col.gameObject.GetComponent<Rigidbody2D> ().AddForce ((Vector2)(col.transform.position - transform.position) * force);
        }
        if (col.gameObject.tag != "Enemy")
            Destroy(gameObject);
    }

	public void setDamage (int damage) {
		this.damage = damage;
	}

	public void setForce (float force) {
		this.force = force;
	}

	public void setSpeed (float speed) {
		this.speed = speed;
	}
}
