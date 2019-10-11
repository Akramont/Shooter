using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBots : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletRight;
    public GameObject bulletLeft;
    public static int i;
    public GameObject menu;
    public Vector3 offsetRight;
    public Vector3 offsetLeft;

    private bool isReward = false;
    private List<Vector3> positionList;
    private List<int> bullet;
    private int bulletNext;
    private float shut = 0;
    private bool faceRight = true;
    private SpriteRenderer sprite;
    private Animator anim;              // Аниматор
    private float delay = Player.delay;

    void Start()
    {
        positionList = new List<Vector3>();
        bullet = new List<int>();
        player = GameObject.Find("Player");
        menu = GameObject.Find("PanelChange");
        menu.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isReward)
        {
            if (i < positionList.Count)
            {
                if (i < 10)
                {
                    bulletNext = 0;
                }
                transform.position = positionList[i];
                if (i != 0 && positionList[i].x > positionList[i - 1].x)
                {
                    faceRight = true;
                    sprite.flipX = false;
                    anim.SetFloat("Speed", 1f);
                }

                else if (i != 0 && positionList[i].x < positionList[i - 1].x)
                {
                    faceRight = false;
                    sprite.flipX = true;
                    anim.SetFloat("Speed", 1f);
                }
                else
                {
                    anim.SetFloat("Speed", 0f);
                }
                if (bulletNext < bullet.Count && i >= bullet[bulletNext])
                {
                    anim.SetBool("Attack", true);
                    fire();
                    bulletNext++;
                }
                else
                {
                    anim.SetBool("Attack", false);
                }
            }
            else
            {
                transform.position = new Vector3(-30, -80, 0);
            }
        }
        else
        {
            positionList.Add(player.transform.position);
            if (Input.GetAxisRaw("Fire1") == 1 && Time.time > shut + delay)
            {
                bullet.Add(i);
                shut = Time.time;
            }
            if (menu.active)
            {
                isReward = true;
            }
        }
    }

    void fire()
    {
        if (faceRight)
        {
            Instantiate(bulletRight, transform.position + offsetRight, Quaternion.identity); //Создание пули
        }
        else
        {
            Instantiate(bulletLeft, transform.position + offsetLeft, Quaternion.identity); //Создание пули
        }
    }

    void OnTriggerEnter2D(Collider2D collision) //Пересечения коллайдеров
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}