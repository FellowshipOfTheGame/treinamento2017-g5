using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSize : MonoBehaviour {
    
	void Awake () {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Camera cam = Camera.main;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        Vector3 scale = new Vector3(width / sr.bounds.extents.x, height / sr.bounds.extents.y, 1f);
        transform.localScale = scale;        
    }

    void LateUpdate()
    {
        Camera cam = Camera.main;
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -5f);
    }
	
}
