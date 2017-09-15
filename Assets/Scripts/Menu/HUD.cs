using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    public Sprite[] LifeSprites;
    public Image LifeUI;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            LifeUI.enabled = false;
        else
            LifeUI.enabled = true;


        LifeUI.sprite = LifeSprites[CatSwitchScript.Instance.hp];

    }

}
