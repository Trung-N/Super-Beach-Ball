using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour {

    public float scrollSpeed;

    void Start () {
    }

    void Update () {
        float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
        float a = Time.time * scrollSpeed;
        GetComponent<Renderer> ().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(a, 0));
    }

}
