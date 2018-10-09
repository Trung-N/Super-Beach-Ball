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
      transform.position = new Vector3(transform.position.x, transform.position.y + jumpspeed * (Time.deltaTime*5), transform.position.z);
      jumpspeed=jumpspeed-(Time.deltaTime*5);
      if(jumpspeed<-2.0f){
        jump = false;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
      }
    }
    if (Input.GetKeyDown(KeyCode.Z) && !jump)
      {
          jump = true;
          jumpspeed = 2.0f;

      }
	    if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = this.gameObject.transform.position;
        }
    }
}
