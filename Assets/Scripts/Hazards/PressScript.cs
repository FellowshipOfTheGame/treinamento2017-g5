using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressScript : MonoBehaviour {

	private Rigidbody2D Rigid;
	public Transform P1;
	public Transform P2;
	public LayerMask Player;

	public int damage;
	public float force;
	public float unfallSpeed;

	private bool falling;
	private bool upping;
	private float startHeight;

	// Use this for initialization
	void Start () {
		Rigid = GetComponent<Rigidbody2D> ();
		falling = false;
		upping = false;
		startHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		Fall ();
		Up ();
	}

	void Fall () {
		if (DetectPlayer () && !falling) {
			falling = true;
		}
		if (!falling) {
			Rigid.gravityScale = 0f;
		} else {
			Rigid.gravityScale = 1f;
		}
	}

	void Up () {
		if (upping) {
			Rigid.velocity = new Vector2 (0f, unfallSpeed);
		}
		if (transform.position.y >= startHeight) {
			Rigid.velocity = Vector2.zero;
			upping = false;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag.Substring(0,4) == "Gato")
        {
            col.gameObject.GetComponent<AllCatsBehaviour>().Hit(damage);
            col.gameObject.GetComponent<Rigidbody2D> ().AddForce ((Vector2)(col.transform.position - transform.position).normalized * force);
		} else if (col.gameObject.tag == "Ground") {
            SoundEffectsScript.Instance.MakePressSound();
			falling = false;
			upping = true;
		}
	}

	bool DetectPlayer () {
		return Physics2D.OverlapArea ((Vector2) P1.position, (Vector2) P2.position, Player);
	}

	Vector3 Center () {
		return (P1.position + P2.position) / 2;
	}

	Vector3 Size () {
		return new Vector3 (Mathf.Abs (P1.position.x - P2.position.x),
							Mathf.Abs (P1.position.y - P2.position.y),
							Mathf.Abs (P1.position.z - P2.position.z));
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (Center (), Size ());
	}

}
