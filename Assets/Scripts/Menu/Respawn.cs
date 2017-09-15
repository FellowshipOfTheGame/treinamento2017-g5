using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {
    
    public Canvas respawnMenu;
    public Button respawnButton;
    public Button mainMenu;
    private Camera sceneCamera;

	// Use this for initialization
	void Awake () {
        respawnMenu = respawnMenu.GetComponent<Canvas>();
        respawnButton = respawnButton.GetComponent<Button>();
        mainMenu = mainMenu.GetComponent<Button>();
        sceneCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        respawnMenu.enabled = false;

    }

    public void mainMenuPress()
    {
        Time.timeScale = 1.0f;
        Destroy(GameObject.Find("Main Camera"));
        SceneManager.LoadScene("Menu");
    }
    
    public void respawnPress()
    {
        respawnMenu.enabled = false;
        Time.timeScale = 1.0f;
    }
	
	public void RespawnMenu () {
            Time.timeScale = 0.0f;
            respawnMenu.enabled = true;
	}
}
