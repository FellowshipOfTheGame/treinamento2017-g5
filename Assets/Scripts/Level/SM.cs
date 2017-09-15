using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM : MonoBehaviour {
    
    public string nextLevel;
    private CatSwitchScript CS;

    private void Start()
    {
        CS = GameObject.FindGameObjectWithTag("CatSwitch").GetComponent<CatSwitchScript>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag.Substring(0, 4) == "Gato" && Input.GetKeyDown(KeyCode.DownArrow))
        {
            CS.Positions[SceneManager.GetActiveScene().buildIndex - 1] = CS.Cat.transform.position;
            SceneManager.LoadScene(nextLevel);
        }
    }

}
