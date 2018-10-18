using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float speed = 1.0f;
    public float range = 4.5f;
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= range * - 1)
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= range)
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
