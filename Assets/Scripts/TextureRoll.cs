using UnityEngine;
using System.Collections;

public class TextureRoll : MonoBehaviour {

    public float scrollSpeed;

    void Start () {
    }

    void Update () {
        float a = Time.time * scrollSpeed;
        GetComponent<Renderer> ().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(a, 0));
    }

}
