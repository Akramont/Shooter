using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float delay = 0.2f;          // Задержка между выстрелами
    public float speed;                 // Скорость персонажа
    public int numberPlayer;            // Номер активного персонажа
    public GameObject[] players;        // Список персонажей
    public GameObject[] bulletLeft;     // Пули влево
    public GameObject[] bulletRight;    // Пули вправо
    public GameObject[] bots;           // Список ботов
    public Vector3[] offsetRight;       // Смещение пули вправо
    public Vector3[] offsetLeft;        // Смещение пули влево
    public GameObject menu;             // Меню изменения персонажа после смерти
    public GameObject respawnPlayer;    // Точка старта

    private float shut = 0;             // Время последнего выстрела
    private Rigidbody2D rb2d;           // Физика персонажа
    private bool onJump = true;         // Проверка на прыжок
    private SpriteRenderer[] sprite;    // Анимация перонажа
    private bool faceRight = true;      // Поворот направо
    [SerializeField]
    private int lifePlayer = 3;         // Жизнь игрока

    public void playerOne()
    {
        numberPlayer = 0;
        respawn();
    }

    public void playerTwo()
    {
        numberPlayer = 1;
        respawn();
    }

    private void enable()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.SetActive(false);
        }
        players[numberPlayer].gameObject.SetActive(true);
    }

    void respawn()
    {
        Instantiate(bots[numberPlayer], new Vector3(-30, -80, 0), Quaternion.identity);
        lifePlayer = 3;
        transform.position = respawnPlayer.transform.position;
        enable();
        PlayerBots.i = 0;
    }

    void death()
    {
        transform.position = new Vector3(-30, -80, 0);
        menu.SetActive(true);
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = new SpriteRenderer[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            sprite[i] = players[i].GetComponent<SpriteRenderer>();
        }
    }

    void FixedUpdate()
    {
        PlayerBots.i++;
        // Выстрел
        if (Input.GetAxisRaw("Fire1") == 1 && Time.time > shut + delay) //
        {
            shut = Time.time;             // Время выстрела
            Fire();
        }

        // Перемещение
        float move = Input.GetAxisRaw("Horizontal");
        if (move == 1) //Перемещение направо
        {
            faceRight = true;
        }
        if (move == -1) //Перемещение налево
        {
            faceRight = false;
        }
        if (faceRight) // Если идет направо отключить отражение
        {
            sprite[numberPlayer].flipX = false;
        }
        else // Если идет направо Включить отражение
        {
            sprite[numberPlayer].flipX = true;
        }
        Vector2 movement = new Vector2(move * speed, rb2d.velocity.y);
        rb2d.velocity = movement;

        // Прыжок
        if (rb2d.velocity.y == 0) //Если вертикальная скорость равна 0 то прыжок возможен
        {
            onJump = true;
        }
        else
        {
            onJump = false;
        }
        if (Input.GetAxisRaw("Jump") == 1 && onJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f); // Обнуление скорости по y
            rb2d.AddForce(transform.up * 8f, ForceMode2D.Impulse); //Добавление силы в верх
        }

        if(lifePlayer == 0)
        {
            death();
        }
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision) //Пересечения коллайдеров
    {
        if (collision.gameObject.tag == "AreaOfTeleportation")
        {
            lifePlayer = 0;
        }
        if(collision.gameObject.tag == "EnemyBullet")
        {
            lifePlayer--;
            Destroy(collision.gameObject);
        }
    }

    void Fire()
    {
        if (faceRight)
        {
            Instantiate(bulletRight[numberPlayer], transform.position + offsetRight[numberPlayer], Quaternion.identity); //Создание пули
        }
        else
        {
            Instantiate(bulletLeft[numberPlayer], transform.position + offsetLeft[numberPlayer], Quaternion.identity); //Создание пули
        }
    }
}
