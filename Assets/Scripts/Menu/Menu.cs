using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Canvas quitMenu;
	public Button play;
	public Button exit;
    public Canvas settingsMenu;
    public Button mute;
    public Button settingsQuit;
    public Slider volumeSlider;
    public Camera sceneCamera;
    private GameObject BG;

    // Use this for initialization
    void Start () {

		quitMenu = quitMenu.GetComponent<Canvas> ();
		play = play.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();
        settingsMenu = settingsMenu.GetComponent<Canvas> ();
        mute = mute.GetComponent<Button>();
        settingsQuit = settingsQuit.GetComponent<Button>();
        volumeSlider = volumeSlider.GetComponent<Slider>();
        sceneCamera = sceneCamera.GetComponent<Camera>();
        BG = GameObject.FindGameObjectWithTag("BG");
        settingsMenu.enabled = false;
		quitMenu.enabled = false;

        DontDestroyOnLoad(sceneCamera);
	}

	public void ExitPress(){
		quitMenu.enabled = true;
	}

	public void NoPress(){
		quitMenu.enabled = false;
	}

    public void SettingPress()
    {
        settingsMenu.enabled = true;
    }

    public void SettingQuitPress()
    {
        settingsMenu.enabled = false;
    }

    public void StartLevel(){
		SceneManager.LoadScene ("Level1.1");
	}

    public void MutePress()
    {
        BG.GetComponent<AudioSource>().mute = !BG.GetComponent<AudioSource>().mute;
    }

	public void ExitGame(){
		Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {
        BG.GetComponent<AudioSource>().volume = volumeSlider.value;
        //sceneCamera.GetComponent<AudioSource>;
    }
}
