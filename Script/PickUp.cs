using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private GameObject itemButton;
    private Collider2D thisColider;
    private void Awake() 
    {
        thisColider=transform.GetComponent<Collider2D>();
    }
    void Start()
    {
        inventory=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        StartCoroutine(waitForPickUp());
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
            for(int i=0;i<inventory.slots.Length;i++)
                if(!inventory.isFull[i])
                {
                    inventory.isFull[i]=true;
                    Instantiate(itemButton,inventory.slots[i].transform,false);
                    Destroy(gameObject);
                    break;
                }

    }

    IEnumerator waitForPickUp()
    {
        yield return new WaitForSeconds(1);
        thisColider.enabled=true;
    }

}
