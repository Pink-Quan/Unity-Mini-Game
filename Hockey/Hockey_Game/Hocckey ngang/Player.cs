using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Velocity;
    [SerializeField] private BulletScript Bullet;
    [SerializeField] private Transform localshot;
    private Rigidbody2D thisRigidbody2D;
    private float temp,right,left,up,down;
	void Start()
    {
        thisRigidbody2D=transform.GetComponent<Rigidbody2D>();
        temp = Velocity;
    }

    void Update()
    {
        thisRigidbody2D.velocity = Vector2.zero;
        if (transform.position.x < -8) Velocity = 0.5f; else Velocity = temp;

        if (Input.GetKey(KeyCode.W)) up=1f; else up=0f;
        if (Input.GetKey(KeyCode.S)) down=-1f; else down=0f;
        if (Input.GetKey(KeyCode.A)) left=-1f; else left=0f;
        if (Input.GetKey(KeyCode.D)) right=1f; else right=0f;
         
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SoundScript.instance.gunSound();
            fire();
        }
    }
    private void FixedUpdate() 
    {
        thisRigidbody2D.velocity=new Vector2(right+left,up+down)*Velocity;    
    }
    private void fire()
    {
        BulletScript tempBullet = Instantiate(Bullet);
        tempBullet.transform.position = localshot.transform.position;
    }
}
