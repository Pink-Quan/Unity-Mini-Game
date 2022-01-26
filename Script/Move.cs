using System.Diagnostics.Tracing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float velocity;
    private float left=0,rigt=0,up=0,down=0;
    void Update()
    {
        if(Input.GetKey(KeyCode.A)) left=-1; else left=0;
        if(Input.GetKey(KeyCode.D)) rigt=1; else rigt=0;
        if(Input.GetKey(KeyCode.W)) up=1; else up=0;
        if(Input.GetKey(KeyCode.S)) down=-1; else down=0;
    }
    private void FixedUpdate() 
    {
        rb.velocity=new Vector2(rigt+left,up+down)*velocity;   
    }
}
