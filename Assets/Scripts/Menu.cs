using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	private int mode = 1;
	public GameObject option;
	public Text modeDisplay;

	public void PlayGame () {
		if(mode == 1){
			SceneManager.LoadScene("Easy");
		}
		else{
			SceneManager.LoadScene("Hard");
		}

	}

	public void QuitGame () {
		Application.Quit();
	}
	public void Options () {
		option.SetActive(true);
		mode = PlayerPrefs.GetInt ("mode", mode);
		this.DisplayMode();
	}
	public void Back () {
		option.SetActive(false);
	}
	public void ChangeDif () {
		if(mode == 1){
			this.SetHard();
		}
		else{
			this.SetNormal();
		}
	}

	private void DisplayMode(){
		if(mode == 1){
			modeDisplay.text = "Easy";
		}
		else{
			modeDisplay.text = "Hard";
		}
	}

	private void SetHard () {
		mode = 2;
		PlayerPrefs.SetInt ("mode", 2);
		this.DisplayMode();
	}
	private void SetNormal () {
		mode = 1;
		PlayerPrefs.SetInt ("mode", 1);
		this.DisplayMode();
	}
}
