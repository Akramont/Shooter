using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{

    public float delay = 0.5f;
    public GameObject bulletEnemy;

    private float shut = 0;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Time.time > shut + delay)
            {
                Instantiate(bulletEnemy, transform.position + new Vector3(), Quaternion.identity);
                shut = Time.time;
            }
        }
    }
}
