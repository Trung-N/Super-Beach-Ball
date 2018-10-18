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
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + mode);
	}

	public void QuitGame () {
		Application.Quit();
	}
	public void Options () {
		option.SetActive(true);
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
			modeDisplay.text = "Normal";
		}
		else{
			modeDisplay.text = "Hard";
		}
	}

	private void SetHard () {
		mode = 2;
		this.DisplayMode();
	}
	private void SetNormal () {
		mode = 1;
		this.DisplayMode();
	}
}
