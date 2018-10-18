using UnityEngine;
﻿using UnityEngine.UI;
﻿using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameoverMenu : MonoBehaviour {
	public Text scoreDisplay;
	public Text killDisplay;


	public void retry () {
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  public void QuitToMenu () {
  	  SceneManager.LoadScene(0);
    }

		public void setScore (int score, int kills) {
			scoreDisplay.text =score + "POINTS";
			killDisplay.text =kills + "KILLS";
	    }
}
