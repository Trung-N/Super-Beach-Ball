using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	private int score = 0;
	private float timer = 0.0f;
	public Text scoreDisplay;
	public Text killDisplay;
	private int killCount = 0;
	public GameObject controls;


	// Use this for initialization
	void Start () {
		scoreDisplay.text = "Score: "+score;
		killDisplay.text = "Kills: "+killCount;
	}

	void Update () {
		if(score > 1000){
			controls.SetActive(false);
		}
	}


	public void gainScore () {
		if (timer >= 0.1){
			score += 10;
			timer -= 0.1f;
			scoreDisplay.text = "Score: "+score;
		}
		timer += Time.deltaTime;
	}

	public void gainKill () {
			score += 1000;
			killCount++;
			scoreDisplay.text = "Score: "+score;
			killDisplay.text = "Kills: "+killCount;
	}

	public int getScore () {
			return score;
	}

	public int getKill () {
			return killCount;
	}
}
