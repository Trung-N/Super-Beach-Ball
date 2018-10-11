using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed; // Default speed sensitivity
    public GameObject projectilePrefab;
    public GameObject gameover;
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
        transform.position = new Vector3(transform.position.x, 0.01f, transform.position.z);
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
            projectile.transform.position = this.gameObject.transform.position + new Vector3(0.0f, 0.0f, 1.0f);
        }
        GameObject score =  GameObject.Find("score");
        score.gameObject.GetComponent<ScoreScript>().gainScore();
    }

    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        // Destroy self
        Destroy(this.gameObject);
        gameover.SetActive(true);
        GameObject score =  GameObject.Find("score");
        gameover.gameObject.GetComponent<GameoverMenu>().setScore(score.gameObject.GetComponent<ScoreScript>().getScore(), score.gameObject.GetComponent<ScoreScript>().getKill());
    }
}
