using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScript : MonoBehaviour {
	public float speed;


	// Update is called once per frame
	void Update () {
		speed += Time.deltaTime/10;
	}

	public float getSpeed(){
		return speed;
	}
}
