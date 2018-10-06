using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterScript : MonoBehaviour
{
    public Shader shader;
    public PointLight pointLight;
    public int n = 2;
    private float count =0;

    void Start()
    {
        MeshFilter waterMesh = this.gameObject.AddComponent<MeshFilter>();
        waterMesh.mesh = this.CreateWaterMesh();


        MeshRenderer renderer = this.gameObject.AddComponent<MeshRenderer>();
        renderer.material.shader = shader;
    }

    // Called each frame
    void Update()
    {
    transform.Translate(Vector3.back * Time.deltaTime);
    this.count +=Time.deltaTime;
    if (this.count >=7){
      transform.Translate(Vector3.forward * this.count);
      this.count = 0;
    }
    }



    Mesh CreateWaterMesh()
    {
        Mesh m = new Mesh();
        m.name = "Water";

        int length = (1<<n)+1;

        List<Vector3> vertices = new List<Vector3>();
        List<Color> colors = new List<Color>();
        List<int> triangles = new List<int>();
        //get max height

        //generate vertices with x, y, z coordinators and its color
        int colorSet = 0;
        for(int row = 0; row < length; row++){
        	for (int col = 0; col < length; col ++){
                vertices.Add(new Vector3(row - (length-1)/2, 0, col - (length-1)/2));
                if(col%7==0 || col%7==1){
                  colors.Add(new Color(0.0f,0.0f,0.0f,0.1f));
                }
                else{
                  colors.Add(new Color(4.0f,2.0f,1.0f));
                }

                if(col<(length-1) && row<(length-1)){
                  triangles.Add((row*length)+col);
                  triangles.Add(((row)*length)+col+1);
                  triangles.Add(((row+1)*length)+col+1);

                  triangles.Add((row*length)+col);
                  triangles.Add(((row+1)*length)+col+1);
                  triangles.Add(((row+1)*length)+col);
                }
        	}
        }

        m.vertices = vertices.ToArray();
        m.triangles = triangles.ToArray();
        m.colors = colors.ToArray();
        return m;
    }
}
