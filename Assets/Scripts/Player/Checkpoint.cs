using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour {

	private Transform CatSwitch;
    private CatSwitchScript CS;

    private SpriteRenderer SR;
    public List<Sprite> sprites;
    
	void Start () {
        CatSwitch = GameObject.FindGameObjectWithTag("CatSwitch").transform;
        CS = GameObject.FindGameObjectWithTag("CatSwitch").GetComponent<CatSwitchScript>();
        SR = GetComponent<SpriteRenderer>();
        SR.sprite = sprites[0];

    }

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag.Substring (0, 4) == "Gato") {
			CatSwitch.position = transform.position;
            CS.Positions[SceneManager.GetActiveScene().buildIndex - 1] = CS.Cat.transform.position;
            SR.sprite = sprites[1];
        }
	}
}
