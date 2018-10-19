using UnityEngine;
﻿using UnityEngine.UI;
﻿using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameoverMenu : MonoBehaviour {
	public Text scoreDisplay;
	public Text killDisplay;
	public Text highscoreDisplay;
	private int highscore;


	public void retry () {
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  public void QuitToMenu () {
  	  SceneManager.LoadScene(0);
    }

		public void setScore (int score, int kills) {
			scoreDisplay.text ="YOUR SCORE: " + score;
			killDisplay.text ="KILLS: " + kills;
			highscore = PlayerPrefs.GetInt ("highscore", highscore);
			highscoreDisplay.text = "HIGHSCORE: " + highscore;
			if(score>highscore){
				PlayerPrefs.SetInt ("highscore", score);
				highscoreDisplay.text = "NEW HIGHSCORE: " + score;
			}
	  }
}
