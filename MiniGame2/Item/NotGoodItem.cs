using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGoodItem : MonoBehaviour
{
    [SerializeField] private float dieTime=3f,damge=1;
    void Start()
    {
        StartCoroutine(die());
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name=="Player")
        {
            TakeDamge enemy=other.gameObject.GetComponent<TakeDamge>();
            enemy.TakeDamge(damge);
            SimplePool.Despawn(gameObject);
        }
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(dieTime);
        SimplePool.Despawn(gameObject);
    }
}
