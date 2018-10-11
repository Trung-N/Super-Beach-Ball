using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwarmManager : MonoBehaviour
{

    // External parameters/variables
    public GameObject enemyTemplate;

    public float maxGenTime = 2.0f;
    public float minGenTime = 1.0f;
    public float generationTimer = 2;
    public float range = 10;
    public int genSize = 1;
    public float speed;


    // Use this for initialization
    void Start () {
        this.generationTimer = Random.Range(minGenTime,maxGenTime);
	}




	// Update is called once per frame
	void Update () {
        this.generationTimer -= Time.deltaTime;
        if (this.generationTimer < 0.0f)
        {
            GenerateRow();
            this.generationTimer = Random.Range(minGenTime,maxGenTime);
        }
        speed+=Time.deltaTime/10;
	}


    // Method to generate swarm of enemies randomly ## Zhuoping Miao
    private void GenerateRow()
    {
        int swarmNumber = Random.Range(1, genSize);
        float col = Random.Range(0-range,range-swarmNumber);

        for (int i = 0; i < swarmNumber; i++){
            GameObject enemy = GameObject.Instantiate<GameObject>(enemyTemplate);
            enemy.transform.parent = this.transform;
            enemy.transform.localPosition = new Vector3(col*1.0f+0.5f, 0.0f, 0.0f);
            BlockController blockScript = enemy.GetComponent<BlockController>();
            if (blockScript == null){
              EnemyController enemyScript = enemy.GetComponent<EnemyController>();
              enemyScript.setSpeed(speed);
            }
            else{
              blockScript.setSpeed(speed);
            }
            col++;
        }
    }

}
