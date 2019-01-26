using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour

{
    private MeshRenderer mr;
    private Vector2 offset;
    private Material mat;
    [SerializeField] private float parallax = 2f;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        
    }

    void Update()
    {
        //offset.x += Time.deltaTime / 10f;
        offset.x = transform.position.x / transform.localScale.x / parallax;
        offset.y = transform.position.y / transform.localScale.y / parallax;
        mat.mainTextureOffset = offset;
    }
}
