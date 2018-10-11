using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundScript : MonoBehaviour
{
    public float speed = 5;
    private float count =0;


    // Called each frame
    void Update()
    {
      transform.Translate(Vector3.back * Time.deltaTime*speed);
      this.count +=Time.deltaTime*speed;
      if (this.count >=10){
        transform.Translate(Vector3.forward * this.count);
        this.count = 0;
      }
      speed+=Time.deltaTime/10;
    }

}
