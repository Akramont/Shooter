using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBots : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletRight;
    public GameObject bulletLeft;
    public static int i;
    public float delay = 0.2f;
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

    void Start()
    {
        positionList = new List<Vector3>();
        bullet = new List<int>();
        player = GameObject.Find("Player");
        menu = GameObject.Find("PanelChange");
        menu.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
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
                }
                if (i != 0 && positionList[i].x < positionList[i - 1].x)
                {
                    faceRight = false;
                    sprite.flipX = true;
                }
                if (bulletNext < bullet.Count && i == bullet[bulletNext])
                {
                    fire();
                    bulletNext++;
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
