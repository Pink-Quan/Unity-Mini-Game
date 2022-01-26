using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] private GameObject item;
    void Start()
    {
        playerPos=GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItems()
    {
        Vector2 throwPos= new Vector2 (playerPos.position.x,playerPos.position.y);
        Instantiate(item,throwPos,Quaternion.identity);
    }
}
