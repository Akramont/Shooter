using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoll : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed*speed;

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed * speed;
    }
}
