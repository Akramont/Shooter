using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonCharacter : MonoBehaviour
{
    public float delay;
    private float shut = 0;
    public float speed;
    private Rigidbody2D rb2d;
    private Animator anim;
    public GameObject fireBall;
    public Text FinishText;
    private bool onJump = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        FinishText.text = "";
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
        if (Input.GetKey(KeyCode.Q) && onJump)
        {
            rb2d.AddForce(transform.up * 4f, ForceMode2D.Impulse);
        }
        Vector2 movement = new Vector2(move * speed, rb2d.velocity.y);
        rb2d.velocity = movement;
        AI.i++;
    }

    void Fire()
    {
        Instantiate(fireBall, transform.position + new Vector3(0.55f, -0.55f, 0), Quaternion.identity);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onJump = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            FinishText.text = "Finish!";
        }

        if (collision.gameObject.tag == "AreaOfTeleportation")
        {
            transform.position = new Vector3(0, 0, 0);
        }

    }

}
