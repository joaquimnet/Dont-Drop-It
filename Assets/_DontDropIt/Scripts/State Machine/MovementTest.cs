using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.Translate(new Vector3(movement, 0f, 0f));
    }
}
