using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doc_Enemy : MonoBehaviour
{
    [SerializeField] Transform ball;
    [SerializeField] float velocity;
    void Update()
    {
        if (ball.transform.localPosition.x >= 0)
        {
            if (ball.transform.localPosition.x > transform.localPosition.x + 0.1)
                transform.localPosition += new Vector3(1, 0, 0) * Time.deltaTime * velocity;
            if (ball.transform.localPosition.y < transform.localPosition.x + 0.1)
                transform.localPosition -= new Vector3(1, 0, 0) * Time.deltaTime * velocity;
        }
        else
        {
            if (transform.localPosition.x > 0)
                transform.localPosition -= new Vector3(1, 0, 0) * Time.deltaTime * velocity;
            if (transform.localPosition.y < 0)
                transform.localPosition += new Vector3(1, 0, 0) * Time.deltaTime * velocity;
        }
        if (transform.localPosition.y > 3)
        {
            transform.localPosition += Vector3.down * Time.deltaTime;
        }
        if (transform.localPosition.y < 3)
        {
            transform.localPosition += Vector3.up * Time.deltaTime;
        }
    }
}
