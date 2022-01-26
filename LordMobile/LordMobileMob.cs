using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordMobileMob : MonoBehaviour,TakeDamge
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private LordMobile_Controller controller;
    bool isEnemy;
    LordMobileMob taget;
    public int mobIndex{private set;get;}
    public void setData(bool isEnemy,LordMobile_Controller Controller,int index)
    {
        mobIndex=index;
        this.isEnemy=isEnemy;
        controller=Controller;
        if(isEnemy)
        {
            spriteRenderer.color=Color.red;
        }
        else
        {
            spriteRenderer.color=Color.blue;
        }
        HP=maxHP;
    }
    private void Update() 
    {
        if(taget!=null&&taget.gameObject.activeSelf)
        {
            if(getDistance(transform,taget.transform)>1)
                AimTaget();
            else
                AttackTaget();

            return;
        }
        SeekTaget();
    }
    private void SeekTaget()
    {
        float sqrtDistance=10000f;
        float minDistance=10000f;
        int minDistanceIndex=-1;
        if(isEnemy)
        {
            foreach(var mob in controller.AllyDictionary.Values)
            {
                sqrtDistance=getDistance(transform,mob.transform);
                if(minDistance>sqrtDistance)
                {
                    minDistance=sqrtDistance;
                    minDistanceIndex=mob.mobIndex;
                }
            }
            if(minDistanceIndex>-1)
            taget=controller.AllyDictionary[minDistanceIndex];
        }
        else
        {
            foreach(var mob in controller.EnemyDictionary.Values)
            {
                sqrtDistance=getDistance(transform,mob.transform);
                if(minDistance>sqrtDistance)
                {
                    minDistance=sqrtDistance;
                    minDistanceIndex=mob.mobIndex;
                }
                if(minDistanceIndex>-1)
                taget=controller.EnemyDictionary[minDistanceIndex];
            }
        }
    }
    [Header("Move stats")]
    [SerializeField] private float velocity;
    private void AimTaget()
    {
        transform.position+=getDirection(taget.transform)*velocity*Time.deltaTime;
    }
    [SerializeField] private float atkCooldowm=1f;
    private float atkTimer=0f;
    private void AttackTaget()
    {
        atkTimer+=Time.deltaTime;
        if(atkTimer>atkCooldowm)
        {
            taget.TakeDamge(damge);
            atkTimer=0f;
        }
    }
    private Vector3 getDirection(Transform taget)
    {
        return (taget.transform.position-transform.position).normalized;
    }
    private float getDistance(Transform locA,Transform locB)
    {
        return (locA.position-locB.position).sqrMagnitude;
    }
    [Header("Mob stats")]
    [SerializeField] private float maxHP=100f;
    [SerializeField] private float damge=20f;
    private float HP;
    public void TakeDamge(float damgeTaken)
    {
        HP-=damgeTaken;
        if(HP<=0)
        {
            SimplePool.Despawn(gameObject);
            if(isEnemy)
            {
                controller.EnemyDictionary.Remove(mobIndex);
            }
            else
            {
                controller.AllyDictionary.Remove(mobIndex);
            }
        }
           
    }
    
}
