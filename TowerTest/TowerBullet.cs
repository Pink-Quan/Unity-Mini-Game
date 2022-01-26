using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    [SerializeField] private float velocity=10f;
    [SerializeField] private float damge=30f;
    private Vector3 direction;
    private Enemy taget;
    public void SetInfor(Vector3 Direction,Enemy Taget)
    {
        taget=Taget;
        direction=Direction;
        transform.localEulerAngles=Vector3.forward*Vector2.SignedAngle(Vector2.right,direction);
    }
    private void FixedUpdate() 
    {
        transform.position+=velocity*direction;
    }   
    private void OnTriggerEnter2D(Collider2D other) 
    {
        TakeDamge enemy=other.GetComponent<TakeDamge>();
        enemy.TakeDamge(damge);
        SimplePool.Despawn(gameObject);
    }
}
