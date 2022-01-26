using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerTestGameManager controller;
    private Enemy taget;
    private void SeekTaget()
    {
        float sqrtDistance=10000f;
        float minDistance=10000f;
        int minDistanceIndex=-1;
        foreach(var enemy in controller.enemyDic.Values)
        {
            sqrtDistance=getDistance(transform,enemy.transform);
                if(minDistance>sqrtDistance)
                {
                    minDistance=sqrtDistance;
                    minDistanceIndex=enemy.enemyIndex;
                }
            if(minDistanceIndex>-1)
            taget=controller.enemyDic[minDistanceIndex];
        }
        
    }
    private float getDistance(Transform locA,Transform locB)
    {
        return (locA.position-locB.position).sqrMagnitude;
    }
    [SerializeField] private TowerBullet towerBullet;
    private TowerBullet tempBullet;
    [SerializeField] private Transform bulletContener,firePos;

    private void ShotTarget()
    {
        tempBullet=SimplePool.Spawn(towerBullet);
        tempBullet.transform.parent=bulletContener;
        tempBullet.transform.localPosition=firePos.position;
        tempBullet.SetInfor((taget.transform.position-firePos.position).normalized,taget);
    }
    [SerializeField] private float seekTargetCoolDown=0.1f,attackCoolDown=0.5f;
    private float seekTargetTimer=0f,attackTargetTimer=0f;
    private void Update() 
    {
        seekTargetTimer+=Time.deltaTime;
        if(seekTargetTimer>=seekTargetCoolDown&&(taget==null||!taget.gameObject.activeSelf))
        {
            seekTargetTimer=0f;
            SeekTaget();
        }

        attackTargetTimer+=Time.deltaTime;
        if(attackTargetTimer>=attackCoolDown&&taget!=null&&taget.gameObject.activeSelf)
        {
            attackTargetTimer=0f;
            ShotTarget();
        }
    }
}
