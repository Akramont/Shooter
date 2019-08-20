using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonCharacter : MonoBehaviour
{
    public float delay;                 // Задержка между выстрелами
    //public GameObject[] n;              // Префабы ботов
    public float speed;                 // Скорость персонажа
    public GameObject bullet;           // Пуля
    public Text FinishText;             // Текст победы

    private float shut = 0;             // Время последнего выстрела
    private Rigidbody2D rb2d;           // Физика персонажа
    private Animator anim;              // Аниматор
    private bool onJump = true;         // Проверка на прыжок

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        FinishText.text = "";
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");  // Скорость от 1 до -1
        anim.SetFloat("Speed", Mathf.Abs(move));      // Анимация
        if (Input.GetKey(KeyCode.E) && Time.time > shut + delay) //
        {
            anim.SetBool("Attack", true); // Анимация
            shut = Time.time;             // Время выстрела
            Fire();
        }
        else
        {
            anim.SetBool("Attack", false); // Анимация 
        }
        if (Input.GetKey(KeyCode.Q) && onJump)  // Прыжок
        {
            rb2d.velocity = new Vector2(0f, 0f); // Обнуление скорости
            rb2d.AddForce(transform.up * 10f, ForceMode2D.Impulse); //Добавление силы в верх
        }
        Vector2 movement = new Vector2(move * speed * Time.deltaTime, rb2d.velocity.y); //Скорость персонажа
        rb2d.velocity = movement; //Добавление скорости к физике
        AI.i++;
    }

    void Fire()
    {
        Instantiate(bullet, transform.position + new Vector3(0.55f, -0.55f, 0), Quaternion.identity); //Создание пули
    }

    private void OnCollisionStay2D(Collision2D collision) // Постоянное столкновение с чем-то
    {
        if (collision.gameObject.tag == "Ground")
        {
            onJump = true; //Прыжок возможен
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // Окончание столкновения с чем-то
    {
        onJump = false; //Прыжок не возможен
    }

    void OnTriggerEnter2D(Collider2D collision) //Пересечения коллайдеров
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
