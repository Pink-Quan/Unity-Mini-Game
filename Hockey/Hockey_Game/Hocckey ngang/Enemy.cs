using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform ball;
    [SerializeField] float velocity,stopTime;
    [SerializeField] Toggle isAl;
    [SerializeField] Text TxtAi;
    private Rigidbody2D ThisRigidbody2D;
    private bool canStop;
    private int AiLevel;
    private float temp,right,left,up,down;
    private void Start()
    {
        ThisRigidbody2D = transform.GetComponent<Rigidbody2D>();
        canStop = true;
        AiLevel = 1;
        temp = velocity;
    }
    void Update()
    {
        
        if (isAl.isOn)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                velocity *= 2;
                AiLevel++;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                velocity /= 2;
                AiLevel--;
            }
            TxtAi.text = $"Ai Level {AiLevel}";
            if (ball.transform.localPosition.x >= 0)
            {
                if (ball.transform.localPosition.y > transform.localPosition.y) up=1f; else up=0f;
                if (ball.transform.localPosition.y < transform.localPosition.y) down=-1f; else down=0f;
            }
            else
            {
                if (transform.localPosition.y > 0) down=-0.1f; else down=0f;
                if (transform.localPosition.y < 0)up=0.1f; else up=0f;
            }
            if (transform.localPosition.x > 7) left=-0.1f; else left=0f;
            if (transform.localPosition.x < 7) right=0.11f; else right=0f;
        }
        else
        {
            velocity=30f;
            if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.I)) up=1f; else up=0f;
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.K)) down=-1f; else down=0f;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.J)) left=-1f; else left=0f;
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.L)) right=1f; else right=0f;
            if (Input.GetKey(KeyCode.P))
                StartCoroutine(timestop(canStop));
            if (canStop == false)
                StartCoroutine(skillCountDown());
        }    
    }
    private void FixedUpdate() 
    {
        ThisRigidbody2D.velocity=new Vector2(right+left,up+down)*velocity;   
        if(transform.localPosition.x==7&&transform.localPosition.y==0&&isAl)
            ThisRigidbody2D.velocity=Vector2.zero; 
    }
    IEnumerator skillCountDown()
    {
        yield return new WaitForSeconds(stopTime*2);
        canStop = true;
    }
    IEnumerator timestop(bool CanStop)
    {
        if (CanStop)
        {
            canStop = false;
            Time.timeScale = 0.1f;
            velocity =300;
            yield return new WaitForSeconds(stopTime/10);
            Time.timeScale = 1;
            velocity = 30;
        }
    }
}
