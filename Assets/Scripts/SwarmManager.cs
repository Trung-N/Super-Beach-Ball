using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwarmManager : MonoBehaviour
{

    // External parameters/variables
    public GameObject enemyTemplate;
    //public int enemyRows;
    //public int enemyCols;
    public float stepSize;
    public float stepTime;
    public float maxXDeviation;
    public float planeSize;

    // Internal parameters/variables
    private int direction;
    private float stepCountdown;
    private float swarmWidth;
    private float generationTimer;

    // Use this for initialization
    void Start () {
        GenerateSwarm();
        this.generationTimer = 1.0f;
        // Initial parameters
        this.stepCountdown = this.stepTime;
        this.transform.localPosition = Vector3.left * maxXDeviation; // Start at far left
        this.direction = 1; // Start moving towards the right (positive x-axis)
	}




	// Update is called once per frame
	void Update () {
        this.stepCountdown -= Time.deltaTime;
        this.generationTimer -= Time.deltaTime;
        if (this.generationTimer < 0.0f)
        {
            GenerateSwarm();
            this.generationTimer = 1.0f;
        }
	}


    // Method to generate swarm of enemies randomly ## Zhuoping Miao
    private void GenerateSwarm()
    {
        int swarmNumber = Random.Range(1, 4);
        float lowbound = -20.0f;
        float upbound = 20.0f;
        float col;
        for (int i = 0; i < swarmNumber; i++){
            col = Random.Range(lowbound, upbound);
            if (col >= 0) { upbound = col; }
            else { lowbound = col; }

            GameObject enemy = GameObject.Instantiate<GameObject>(enemyTemplate);
            enemy.transform.parent = this.transform;
            enemy.transform.localPosition = new Vector3(col, 0.0f, planeSize);
        }
        //this.swarmWidth = (enemyCols - 1) * enemySpacing;
    }


    // Method to step a swarm across the screen (or down & reverse when it reaches the edge)
    private void StepSwarm(GameObject swarm)
    {

    }
}
