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
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
