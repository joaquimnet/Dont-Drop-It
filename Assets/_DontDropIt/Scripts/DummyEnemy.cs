using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    public float speed = 5f;

    Transform ball;
    private void Awake()
    {
        ball = FindObjectOfType<Ball>().transform;
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(ball.position - transform.position, ForceMode.Acceleration);
        transform.LookAt(ball.position);
    }
}
