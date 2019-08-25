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

    private bool isReward = false;
    private List<Vector3> positionList;
    private List<int> bullet;
    private int bulletNext;
    private float shut = 0;

    void Start()
    {
        positionList = new List<Vector3>();
        bullet = new List<int>();
        player = GameObject.Find("Player");
        menu = GameObject.Find("PanelChange");
        menu.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isReward)
        {
            if (i < positionList.Count)
            {
                transform.position = positionList[i];
                if (bulletNext < bullet.Count && i == bullet[bulletNext])
                {
                    Instantiate(bulletRight, transform.position + new Vector3(0.55f, -0.55f, 0), Quaternion.identity);
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
}
