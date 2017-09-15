using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour {

    public Transform destiny;
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag.Substring(0, 4) == "Gato" && Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (destiny != null)
            {
                {
                    SoundEffectsScript.Instance.MakeLockingDoorSound();
                    col.transform.position = destiny.position;
                }
            }
            else
            {
                SoundEffectsScript.Instance.MakeTurningHandleSound();
            }
        }
    }
    
}
