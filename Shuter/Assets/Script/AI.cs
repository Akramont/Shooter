using System;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float delay;
    private float shut = 0;
    public GameObject fireBall;
    public GameObject master;
    public GameObject[] n;

    public KeyCode button;
    public static int i;

    private bool isReward = false;
    private List<Vector3> positionList;
    private List<int> fireboll;
    private int firebollNext;
    private Animator anim;

    void Start()
    {
        positionList = new List<Vector3>();
        fireboll = new List<int>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(button) && !isReward)
        {
            master.transform.position = new Vector3(0, 0, 0);
            Instantiate(n[0], new Vector3(-24, 0, 0), Quaternion.identity);
            i = 0;
            isReward = true;
        }
    }

    private void FixedUpdate()
    {
        if (isReward)
        {
            if (i < 10)
            {
                firebollNext = 0;
            }
            if (i < positionList.Count)
            {
                gameObject.layer = 9;
                transform.position = positionList[i];
                if (i != 0 && positionList[i] != positionList[i - 1])
                {
                    anim.SetFloat("Speed", 1);
                }
                else
                {
                    anim.SetFloat("Speed", 0);
                }
                if (firebollNext < fireboll.Count && i == fireboll[firebollNext])
                {
                    anim.SetBool("Attack", true);
                    Instantiate(fireBall, transform.position + new Vector3(0.55f,-0.55f,0), Quaternion.identity);
                    firebollNext++;
                }
                else
                {
                    anim.SetBool("Attack", false);
                }
            }
            else
            {
                anim.SetFloat("Speed", 0);
                gameObject.layer = 10;
                transform.position = new Vector3(-30, -80, 0);
            }
        }
        else
        {
            positionList.Add(master.transform.position);
            if (Input.GetKey(KeyCode.E) && Time.time > shut + delay)
            {
                fireboll.Add(i);
                shut = Time.time;
            }
        }
    }
}
