using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCat : MonoBehaviour {

	public GameObject Cat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag.Substring (0, 4) == "Gato") {
			CatSwitchScript cs = GameObject.FindGameObjectWithTag ("CatSwitch").GetComponent<CatSwitchScript> ();
            if (Cat == null)
            {
                cs.canBruxoAttack = true;
            }
            else
            {
                if (!cs.Cats.Contains(Cat))
                {
                    cs.Cats.Add(Cat);
                }
                cs.SwitchCat(Cat);
            }
            Destroy(gameObject);
        }
	}
}
