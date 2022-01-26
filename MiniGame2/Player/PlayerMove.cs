using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour,TakeDamge
{
    private Rigidbody2D rb;
    [SerializeField] private float velocity=6f;
    [SerializeField] private float maxHP=3;
    private float HP;
    [SerializeField] private GameObject LoseCanvas;
    [SerializeField] private Text LifeText;

    [SerializeField] private float LifeUp=1f,LifeTimerIncreas=5f;
    void Start()
    {
        LifeText.text=$"{maxHP}";
        HP=maxHP;
        rb=GetComponent<Rigidbody2D>();
        StartCoroutine(upLife());
    }
    // private void Update() {
    //     //Move 2
    //     transform.position=Input.mousePosition;
    // }

    IEnumerator upLife()
    {
        while(true)
        {
            yield return new WaitForSeconds(LifeTimerIncreas);
            HP+=LifeUp;
            LifeText.text=$"{HP}";
        }
    }

    private void FixedUpdate() 
    {    
        Vector3 mousePos=Input.mousePosition;
        rb.velocity=getDirection(mousePos)*velocity;
    }
    
    private Vector3 getDirection(Vector3 loc)
    {
        return (loc-transform.position).normalized;
    }

    public void TakeDamge(float damgeTaken)
    {
        HP-=damgeTaken;
        LifeText.text=$"{HP}";
        if(HP<=0)
        {
            Time.timeScale=0f;
            LoseCanvas.gameObject.SetActive(true);
        }
    }
}
