using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {
	public float speed = 5;

	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.back * Time.deltaTime*speed);
				speed+=Time.deltaTime/10;
	}
}
