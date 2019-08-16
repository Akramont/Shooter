using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCharacter : MonoBehaviour
{
    public float delay;
    private float shut = 0;
    public float speed;
    private Rigidbody2D rb2d;
    private Animator anim;
    public GameObject fireBall;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        if (Input.GetKey(KeyCode.E) && Time.time > shut + delay)
        {
            anim.SetBool("Attack", true);
            shut = Time.time;
            Fire();
        }
        else
        {
            anim.SetBool("Attack", false);
        }
        Vector2 movement = new Vector2(move * speed, rb2d.velocity.y);
        rb2d.velocity = movement;
        AI.i++;
    }

    void Fire()
    {
        Instantiate(fireBall, transform.position + new Vector3(0.55f, -0.55f, 0), Quaternion.identity);
    }
}
