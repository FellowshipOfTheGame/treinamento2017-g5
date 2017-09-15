using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour {
    
    private AudioSource audioS;
    
	public float hitRate;
	public int damage;
    public float force;

	private float _time;
    
	void Start () {
        audioS = GetComponent<AudioSource>();
    }
	
    private void OnTriggerEnter2D(Collider2D col)
    {
        SoundEffectsScript.Instance.MakeSplashSound();
        if (col.gameObject.tag == "GatoNadador")
        {
            audioS.enabled = true;
            audioS.loop = true;
            audioS.Play();
        }
    }

    void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.tag.Substring(0,4) == "Gato") {
			AllCatsBehaviour allCats = col.gameObject.GetComponent<AllCatsBehaviour> ();
			if (col.gameObject.tag.Substring (4) == "Nadador") {
                allCats.Rigid.AddRelativeForce(new Vector2(0f, force), ForceMode2D.Force);
			} else {
				_time += Time.deltaTime;
				if (_time > 1 / hitRate) {
                    allCats.Hit(damage);
                    _time = 0f;
				}
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.tag == "GatoNadador")
        {
            audioS.enabled = false;
            audioS.loop = false;
        }
	}

}
