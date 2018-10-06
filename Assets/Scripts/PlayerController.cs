using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 1.0f; // Default speed sensitivity
    public GameObject projectilePrefab;
    private bool jump = false;
    private float jumpspeed;
    private float height;

	// Update is called once per frame
	void Update () {
    if (jump){
      this.transform.Translate(Vector3.up * jumpspeed * (Time.deltaTime*5));
      jumpspeed=jumpspeed-(Time.deltaTime*5);
      if(jumpspeed<-2.0f){
        jump = false;
      }
    }
    if (Input.GetKeyDown(KeyCode.Z) && !jump)
      {
          jump = true;
          jumpspeed = 2.0f;

      }
	    if (Input.GetKeyDown(KeyCode.LeftArrow) && !jump)
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !jump)
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = this.gameObject.transform.position;
        }
    }
}
