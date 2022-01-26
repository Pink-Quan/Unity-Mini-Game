using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodItem : MonoBehaviour
{
    [SerializeField] private float dieTime=3f;
    [SerializeField] private float scoreEat=10f;
    void Start()
    {
        StartCoroutine(die());
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name=="Player")
        {
            MiniGame2GameManager.instance.eatGoodItem(scoreEat);
            SimplePool.Despawn(gameObject);
        }    
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(dieTime);
        SimplePool.Despawn(gameObject);
    }
}
