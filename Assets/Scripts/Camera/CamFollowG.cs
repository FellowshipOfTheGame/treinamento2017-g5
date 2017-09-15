using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamFollowG : MonoBehaviour {

	public float leftLimit, rightLimit, topLimit, downLimit;
	private GameObject player;

	// Update is called once per frame
	void LateUpdate () {
		Scene scene = SceneManager.GetActiveScene ();
		//print (scene.name);
		if (scene.name != "Menu") {

			setLimits ();
			player = GameObject.FindGameObjectWithTag ("CatSwitch").GetComponent<CatSwitchScript> ().Cat;

			transform.position = new Vector3 (Mathf.Clamp (player.transform.position.x, leftLimit, rightLimit), 
				Mathf.Clamp (player.transform.position.y, downLimit, topLimit), transform.position.z);
		}
	}

	public void setLimits(){
        Camera cam = Camera.main;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        leftLimit = GameObject.FindGameObjectWithTag("leftLimit").transform.position.x + width; ;
		rightLimit = GameObject.FindGameObjectWithTag ("rightLimit").transform.position.x - width;
		topLimit = GameObject.FindGameObjectWithTag ("topLimit").transform.position.y - height;
		downLimit = GameObject.FindGameObjectWithTag ("downLimit").transform.position.y + height;
	}

}
