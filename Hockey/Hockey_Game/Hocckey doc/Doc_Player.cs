using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doc_Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ball;
    [SerializeField] private float Velocity;
    private Rigidbody2D thisRigidbody2D;
    private Vector2 moveDirection;
    private float temp;
    void Start()
    {
        thisRigidbody2D = transform.GetComponent<Rigidbody2D>();
        temp = Velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -4)
            Velocity = 0.5f;
        else
            Velocity = temp;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.localPosition += Velocity * new Vector3(0, 1, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.localPosition -= Velocity * new Vector3(0, 1, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localPosition -= Velocity * new Vector3(1, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localPosition += Velocity * new Vector3(1, 0, 0) * Time.deltaTime;
        }
    }
}
