using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public Canvas pauseMenu;
    public Button resume;
    public Button mainMenu;
    public Button mute;
    public Slider volumeSlider;
    private Camera sceneCamera;
    private GameObject BG;

	// Use this for initialization
	void Awake () {
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        resume = resume.GetComponent<Button>();
        mainMenu = mainMenu.GetComponent<Button>();
        mute = mute.GetComponent<Button>();
        volumeSlider = volumeSlider.GetComponent<Slider>();
        sceneCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        BG = GameObject.FindGameObjectWithTag("BG");
        pauseMenu.enabled = false;
        volumeSlider.value = sceneCamera.GetComponent<AudioSource>().volume;

    }

    public void mainMenuPress()
    {
        Time.timeScale = 1.0f;
        Destroy(GameObject.Find("Main Camera"));
        SceneManager.LoadScene("Menu");
    }

    public void MutePress()
    {
        BG.GetComponent<AudioSource>().mute = !BG.GetComponent<AudioSource>().mute;
    }

    public void resumePress()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        BG.GetComponent<AudioSource>().volume = volumeSlider.value;
        if (Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0.0f;
            pauseMenu.enabled = true;
        }
	}
}
