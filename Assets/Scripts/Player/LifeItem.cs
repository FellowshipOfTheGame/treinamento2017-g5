using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Substring(0, 4) == "Gato")
        {
            if (CatSwitchScript.Instance.hp < 7)
            {
                CatSwitchScript.Instance.hp++;
                Destroy(gameObject);
            }
        }
    }

}
