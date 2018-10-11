using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {
	private float speed;

	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.back * Time.deltaTime*speed);
				speed+=Time.deltaTime/10;
	}
	public void setSpeed(float speed)
	{
		this.speed = speed;
	}
}
