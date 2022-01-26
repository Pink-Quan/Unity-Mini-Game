using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private int numberSlot;
    private void Start() 
    {
        inventory=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update() 
    {
        if(transform.childCount<=0)
            inventory.isFull[numberSlot-1]=false;    
    }
    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
            child.GetComponent<Spawn>().SpawnDroppedItems();
        }
    }
}
