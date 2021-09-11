using UnityEngine;
using System;
using System.Collections;

public class bullet_move : MonoBehaviour
{
    float tempx, tempy;
    int time = 0;
    int bullet_speed = 1000;
    Vector3 way;
    bool bounded = false, first = false;
    void Start()
    {
        way.x = Tump_move.Tump_position.x - transform.position.x;
        way.y = Tump_move.Tump_position.y - transform.position.y;
        tempx = way.x * way.x;
        tempy = way.y * way.y;
        way.x /= (float)Math.Sqrt(tempx + tempy);
        way.y /= (float)Math.Sqrt(tempx + tempy);
        way.z = 0;
    }

    void Update()
    {
        transform.position += bullet_speed * way * Time.deltaTime / 100;
        if (transform.position.y >= 50)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "PPAP")
        {
            if (bounded != true)
            {
                bounded = true;
                way.y = -way.y;
                tag = "Bullet_p";
            }
        }
        if (other.gameObject.tag == "Carried" || other.gameObject.tag == "Olt")
        {
            if (bounded != true && Tump_move.move != 3)
            {
                bounded = true;
                way.y = -way.y;
                tag = "Bullet_p";
            }
        }
        if (other.gameObject.tag == "Stop")
        {
            transform.position = new Vector3(-200, 8, 76);
        }
    }
}