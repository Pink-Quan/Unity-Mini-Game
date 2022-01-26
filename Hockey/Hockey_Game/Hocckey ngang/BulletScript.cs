using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float BulletSpeed;
    private Rigidbody2D rb;

    // Update is called once per frame
    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {       
        rb.velocity = Vector2.right * BulletSpeed;
        StartCoroutine(timedie());
    }
    void Update()
    {
        rb.velocity = Vector2.left * BulletSpeed;
    }
    IEnumerator timedie()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    
}
