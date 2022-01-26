using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D thisRigidbody;
    [SerializeField] private float velocityX;
    [SerializeField] private float velocityY;
    [SerializeField] private float bBound;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemyG;
    [SerializeField] private GameObject playerG;
    void Start()
    {
        thisRigidbody=transform.GetComponent<Rigidbody2D>();
        thisRigidbody.velocity = new Vector2(velocityX, velocityY);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name==playerG.name)
        {
            GameManager.instance.changeScore(false);
        }
        if (collision.gameObject.name == enemyG.name)
        {
            GameManager.instance.changeScore(true);
        }
        if (collision.gameObject.name == player.name)
        {
            thisRigidbody.velocity *= bBound;
            SoundScript.instance.hitSound();
        }
        if (collision.gameObject.name == enemy.name)
        {
            thisRigidbody.velocity *= bBound;
            SoundScript.instance.hitSound();
        }
    }
    private void Update()
    { 
        if (thisRigidbody.velocity.x <0.5f&& thisRigidbody.velocity.x > -0.5f && thisRigidbody.velocity.y < 0.5f && thisRigidbody.velocity.y > -0.5f && thisRigidbody.bodyType!=RigidbodyType2D.Kinematic)
            thisRigidbody.velocity = new Vector2(Random.Range(-10,10), Random.Range(-10, 10));
    }



}
