using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTestGameManager : MonoBehaviour
{
    void Start()
    {
        SpawnEnemy();   
    }

    public void OnEnemyDie(int enemyDicIndex)
    {
        SpawnEnemy();   
        SimplePool.Despawn(enemyDic[enemyDicIndex].gameObject);
        enemyDic.Remove(enemyDicIndex);
    }

    [SerializeField] private Enemy enemyPrefab;
    private Enemy tempEnemy;
    [SerializeField] private Transform enemyContainer;
    public Dictionary<int,Enemy> enemyDic =new Dictionary<int, Enemy>();
    private int currenIndex=0;

    private void SpawnEnemy()
    {
        currenIndex++;
        tempEnemy=SimplePool.Spawn(enemyPrefab);
        tempEnemy.transform.parent=enemyContainer;
        tempEnemy.ResetStage(this,currenIndex);
        enemyDic.Add(currenIndex,tempEnemy);
    }
}
