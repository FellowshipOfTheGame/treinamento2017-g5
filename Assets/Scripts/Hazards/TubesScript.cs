using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubesScript : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "GatoEgipcio")
        {
            CatSwitchScript.Instance.canSwitch = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "GatoEgipcio")
        {
            CatSwitchScript.Instance.canSwitch = true;
        }
    }

}
