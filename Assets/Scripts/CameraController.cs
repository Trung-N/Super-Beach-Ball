using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float speed = 1.0f; // Default speed sensitivity
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
