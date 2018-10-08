using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterScript : MonoBehaviour
{
    public float speed = 5;
    private float count =0;
    private float count2 =0;
    private int dir = 1;


    // Called each frame
    void Update()
    {

      transform.Translate(Vector3.back * Time.deltaTime*speed);
      this.count +=Time.deltaTime*speed;
      if (this.count >=10){
        transform.Translate(Vector3.forward * this.count);
        this.count = 0;
      }
      transform.Translate(Vector3.down * Time.deltaTime*dir);
      this.count2 +=Time.deltaTime*dir;
      if (this.count2 >=1){
        this.dir = -1;
      }
      if (this.count2 <=0){
        this.dir = 1;
      }
    }

}
