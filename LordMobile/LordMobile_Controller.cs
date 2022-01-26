using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordMobile_Controller : MonoBehaviour
{
    public Dictionary<int,LordMobileMob> EnemyDictionary=new Dictionary<int,LordMobileMob>();
    public Dictionary<int,LordMobileMob> AllyDictionary=new Dictionary<int,LordMobileMob>();
    [SerializeField] private LordMobileMob prefab;
    private LordMobileMob tempPrefab;
    
    void Start()
    {
        StartCoroutine(spamMobs());
    }


    IEnumerator spamMobs()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            SpamAlies();
            SpamEnemy();
        }
    } 
    public int currentIndex=0;
    private void SpamEnemy()
    {
        tempPrefab=SimplePool.Spawn(prefab);
        tempPrefab.transform.position=new Vector3(Random.Range(0,-9),Random.Range(4,-4),0);
        currentIndex++;
        tempPrefab.setData(true,this,currentIndex);
        EnemyDictionary.Add(currentIndex,tempPrefab);
    }
    private void SpamAlies()
    {
        tempPrefab=SimplePool.Spawn(prefab);
        tempPrefab.transform.position=new Vector3(Random.Range(0,9),Random.Range(4,-4),0);
        currentIndex++;
        tempPrefab.setData(false,this,currentIndex);
        AllyDictionary.Add(currentIndex,tempPrefab);
    }
}
