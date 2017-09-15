using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsteiraScript : MonoBehaviour {

    private ArrayList obj = new ArrayList();
    public float speed;

    private void FixedUpdate()
    {
        foreach (Transform o in obj)
        {
            o.position += new Vector3(speed, 0f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        print(col.collider.tag + " entrou");
        obj.Add(col.transform);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        print(col.collider.tag + " saiu");
        obj.Remove(col.transform);
    }

}
