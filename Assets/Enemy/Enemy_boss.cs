using UnityEngine;
using System.Collections;

public class Enemy_boss : MonoBehaviour
{

    Vector3 enemy_position;
    int move;
    float time = 0;
    public float step = 0.1f;
    public static bool summoned = false;
    bool moved = true;
    float health = 5000;
    int heal = 0, sum = 0;
    float health_p = 100;
    int sp = 10;
    int shootsp = 1;

    void shoot_b()
    {
        Instantiate(GameObject.Find("bomb"), new Vector3(transform.position.x + 0, transform.position.y + 3, transform.position.z), GameObject.Find("bomb").transform.rotation);
    }

    void shoot()
    {
        //-------------------------------------------------------------子彈射擊
        if (Tump_move.Tump_position.y - transform.position.y >= 0)
        {
            if (shootsp == 1)
            {
                Instantiate(GameObject.Find("bullet_B"), new Vector3(transform.position.x + 0, transform.position.y + 3, transform.position.z), GameObject.Find("bullet_B").transform.rotation);
            }
            else if (shootsp == 2)
            {
                Instantiate(GameObject.Find("bullet_B"), new Vector3(transform.position.x + 4, transform.position.y + 0, transform.position.z), GameObject.Find("bullet_B").transform.rotation);
                Instantiate(GameObject.Find("bullet_B"), new Vector3(transform.position.x - 4, transform.position.y + 0, transform.position.z), GameObject.Find("bullet_B").transform.rotation);
            }
            else if (shootsp == 3)
            {
                Instantiate(GameObject.Find("bullet_B"), new Vector3(transform.position.x + 4, transform.position.y + 0, transform.position.z), GameObject.Find("bullet_B").transform.rotation);
                Instantiate(GameObject.Find("bullet_B"), new Vector3(transform.position.x + 0, transform.position.y + 3, transform.position.z), GameObject.Find("bullet_B").transform.rotation);
                Instantiate(GameObject.Find("bullet_B"), new Vector3(transform.position.x - 4, transform.position.y + 0, transform.position.z), GameObject.Find("bullet_B").transform.rotation);
            }

        }
    }

    void Start()
    {
        enemy_position = transform.position;
        InvokeRepeating("shoot", 1f, 0.3f);
        InvokeRepeating("shoot_b", 1f, 5f);
    }

    void Update()
    {
        if ((int)Time.time % sp == 0)
        {
            shootsp = 1;
        }
        else if ((int)Time.time % sp == 3)
        {
            shootsp = 2;
        }
        else if ((int)Time.time % sp == 7)
        {
            shootsp = 3;
        }
        //-----------------------------------------------------------------------MOVE
        if (enemy_position.y <= -30)
        {
            move = 3;
        }
        else if (Tump_move.Tump_position.x - enemy_position.x > 0.5f)
        {
            move = 2;
        }
        else if (Tump_move.Tump_position.x - enemy_position.x < -0.5f)
        {
            move = 1;
        }
        else
        {
            move = 5;
        }


        if (Time.time - time >= 0.05f)
        {
            time = Time.time;
            if (move == 1)
            {
                enemy_position.x -= step;
            }
            else if (move == 2)
            {
                enemy_position.x += step;
            }
            else if (move == 3)
            {
                enemy_position.y += step;
            }
            else if (move == 4)
            {
                enemy_position.y -= step;
            }
            else if (move == 5)
            {
                //enemy_position = enemy_position;
            }
            //-----------------------------------------------------------------------MOVE
            //-----------------------------------------------------------------------health
            GameObject.Find("health_g").transform.localScale -= new Vector3(1 / 0.98f * heal * 1 / 250, 0, 0);
            heal = 0;
            health_p = health / 50;
            if (health <= 0)
            {
                Tump_move.boss_died = true;
                Destroy(gameObject);
            }
            //-----------------------------------------------------------------------health
            //-----------------------------------------------------------------------summon
            if (health_p <= 75 && health_p >= 50 && sum == 0)
            {
                Instantiate(GameObject.Find("Enemy_normal"), new Vector3(transform.position.x + 5, transform.position.y + 0, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_normal"), new Vector3(transform.position.x + 0, transform.position.y + 5, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_normal"), new Vector3(transform.position.x - 5, transform.position.y + 0, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                sum = 1;
            }
            else if (health_p <= 50 && health_p >= 25 && sum == 1)
            {
                Instantiate(GameObject.Find("Enemy_normal"), new Vector3(transform.position.x + 5, transform.position.y + 0, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_normal"), new Vector3(transform.position.x + 0, transform.position.y + 5, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_normal"), new Vector3(transform.position.x - 5, transform.position.y + 0, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_gangster"), new Vector3(transform.position.x + 3, transform.position.y + 5, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_gangster"), new Vector3(transform.position.x - 3, transform.position.y + 5, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                sum = 2;
            }
            else if (health_p <= 25 && health_p >= 0 && sum == 2)
            {
                Instantiate(GameObject.Find("Enemy_normal"), new Vector3(transform.position.x + 5, transform.position.y + 0, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_normal"), new Vector3(transform.position.x + 0, transform.position.y + 5, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_normal"), new Vector3(transform.position.x - 5, transform.position.y + 0, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_gangster"), new Vector3(transform.position.x + 3, transform.position.y + 5, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_gangster"), new Vector3(transform.position.x - 3, transform.position.y + 5, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                Instantiate(GameObject.Find("Enemy_druger"), new Vector3(transform.position.x, transform.position.y + 7, transform.position.z), GameObject.Find("Enemy_normal").transform.rotation);
                sum = 3;
            }
            //-----------------------------------------------------------------------summon
        }

        transform.position = enemy_position;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet_p")
        {
            health -= 20;
            heal++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Stop")
        {
            transform.position = new Vector3(-200, 8, 76);
        }
        if (other.gameObject.name == "Boss_stop")
        {
            enemy_position.y -= 5;
        }
    }
}
