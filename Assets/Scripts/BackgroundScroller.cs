using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    
    [Range(-1f, 1f)]
    public float scrollSpeed = 4;
    private float offset;
    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        
    }

    
    private void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        Debug.Log("Offset " + offset);
        mat.SetTextureOffset("MainTex", new Vector2(offset, 0));
    }
}
