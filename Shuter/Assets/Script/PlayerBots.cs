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

    private bool isReward = false;
    private List<Vector3> positionList;
    private List<int> bullet;
    private int bulletNext;

    void Start()
    {
        positionList = new List<Vector3>();
        bullet = new List<int>();
        player = GameObject.Find("Player");
        menu = GameObject.Find("PanelChange");
    }

    void FixedUpdate()
    {
        if (isReward)
        {
            if (i < positionList.Count)
            {
                transform.position = positionList[i];
            }
            else
            {
                transform.position = new Vector3(-30, -80, 0);
            }
            print("play");
        }
        else
        {
            positionList.Add(player.transform.position);
            if (menu.active)
            {
                isReward = true;
            }
            print("stop");
        }
    }
}
