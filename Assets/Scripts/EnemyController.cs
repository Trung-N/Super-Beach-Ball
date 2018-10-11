using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float speed = 5;
	private float dir;
	public float range = 8.0f;

	void Start () {
			if (Random.Range(0,1)>0)
			{
				dir = 1;
			}
			else
			{
				dir = -1;
			}
}

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.back * Time.deltaTime*speed);
				if (dir > 0)
				{
					transform.position = new Vector3(transform.position.x+Time.deltaTime*speed/2, transform.position.y, transform.position.z);
					if (transform.position.x >= range){
						dir = -1;
					}
				}
				else
				{
					transform.position = new Vector3(transform.position.x-Time.deltaTime*speed/2, transform.position.y, transform.position.z);
					if (transform.position.x <= range*-1){
						dir = 1;
					}
				}
				speed+=Time.deltaTime/10;

	}
}
