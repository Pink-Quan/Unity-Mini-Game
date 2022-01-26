using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private GoodItem gi;
    private GoodItem tgi;
    [SerializeField] private NotGoodItem ngi;
    private NotGoodItem tngi;
    [SerializeField] private float timeSpawn=0.5f;
    [SerializeField] private Transform containItem;
    [SerializeField] private float timeLevelUp=10f,timeSpawnDecreas=0.1f;

    [SerializeField] private float xMinSpawn,xMaxSpawn,ySpawn;
    private void Start() {
        StartCoroutine(spawn());
        StartCoroutine(LevelUp());
    }
    IEnumerator spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeSpawn);
            Debug.Log(timeSpawn);
            if(Random.Range(1,3)==1)
            {
                tngi=SimplePool.Spawn(ngi);
                tngi.transform.position=new Vector2(Random.Range(xMinSpawn,xMaxSpawn),ySpawn);
                tngi.transform.parent=containItem;
            }
            else
            {
                tgi=SimplePool.Spawn(gi);
                tgi.transform.position=new Vector2(Random.Range(xMinSpawn,xMaxSpawn),ySpawn);
                tgi.transform.parent=containItem;
            }     
        }
    }
    IEnumerator LevelUp()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeLevelUp);
            timeSpawn-=timeSpawnDecreas;
            if(timeSpawn<=0)
            {
                timeSpawn=0.05f;
                StopCoroutine(LevelUp());
            }
        }
    }
}
