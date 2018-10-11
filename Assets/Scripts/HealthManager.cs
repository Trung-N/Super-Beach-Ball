using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public GameObject createOnDestroy;


    public void ApplyDamage()
    {
        Destroy(this.gameObject);
        GameObject obj = Instantiate(this.createOnDestroy);
        obj.transform.position = this.transform.position;
        GameObject score =  GameObject.Find("score");
        score.gameObject.GetComponent<ScoreScript>().gainKill();
    }


}
