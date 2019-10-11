using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batton : MonoBehaviour
{
    
    public GameObject barier;
    SpriteRenderer Sprite;
    Collider2D Collider;

    void OnTriggerStay2D(Collider2D collision)             //Взаимодействия между областями и игроком по тегам
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "BotPlayer")    //Барьер выкл
        {
            Sprite.color = Color.green;
            Collider.isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)             //Взаимодействия между областями и игроком по тегам
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "BotPlayer")    //Барьер вкл
        {
            Sprite.color = Color.red;
            Collider.isTrigger = false;
        }
    }

    private void Start()
    {
         Sprite = barier.GetComponent<SpriteRenderer>();
         Collider = barier.GetComponent<Collider2D>();
    }
}
