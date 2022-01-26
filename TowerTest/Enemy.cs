using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,TakeDamge
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private TowerTestGameManager controller;
    [SerializeField] private float maxHP=100f;
    private float HP;
    public int enemyIndex{get;private set;}
    public void ResetStage(TowerTestGameManager Controller,int index)
    {
        controller=Controller;
        HP=maxHP;
        enemyIndex=index;
    }

    public void TakeDamge(float damge)
    {
        HP-=damge;
        if(HP<=0)
        {
            controller.OnEnemyDie(enemyIndex);
        }
    }
}
