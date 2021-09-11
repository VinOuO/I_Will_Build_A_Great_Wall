using UnityEngine;
using System.Collections;

public class Enemy_druger_move : MonoBehaviour
{
    //--------------------------------------stytle
    public Material[] materials;
    Renderer rend;
    //--------------------------------------stytle
    Vector3 enemy_position;
    float time = 0;
    public float step = 0.1f;
    public float speed_contral;
    public int diract;
    public int dizzy = 0, push = 0;
    bool pass = false;
    bool die = false;
    float size = 0;
    public float s = 0.1f;
    public int health = 100;

    float nearest_entrance(int[] wall, float pos, bool[] pp)
    {
        int l = 0, r = 0, ahead = 0, j = 0;
        float p;
        bool get = false;
        for (int i = 0; i <= 14; i++)
        {
            p = wall[i] - pos;
            if (p <= 0)
            {
                p = -p;
            }
            if (p <= 3)
            {
                ahead = i;
                break;
            }
        }
        for (int i = 0; i <= 14; i++)
        {
            if (ahead + i <= 14 && ahead - i >= 0)
            {
                if (pp[ahead + i] == false && pp[ahead - i] == false)
                {
                    return wall[ahead + i];
                }
                if (pp[ahead + i] == false)
                {
                    return wall[ahead + i];
                }
                if (pp[ahead - i] == false)
                {
                    return wall[ahead - i];
                }
            }
            else if (ahead - i >= 0)
            {
                if (pp[ahead - i] == false)
                {
                    return wall[ahead - i];
                }
            }
            else if (ahead + i <= 14)
            {
                if (pp[ahead + i] == false)
                {
                    return wall[ahead + i];
                }
            }
        }
        return 87;
    }
    //-------------------------------------------------------------------------------------------------------
    float nearest_wall(int[] wall, float pos, bool[] pp)
    {
        int l = 0, r = 0, ahead = 0, j = 0;
        float p;
        bool get = false;
        for (int i = 0; i <= 14; i++)
        {
            p = wall[i] - pos;
            if (p <= 0)
            {
                p = -p;
            }
            if (p <= 3)
            {
                ahead = i;
                break;
            }
        }
        for (int i = 0; i <= 14; i++)
        {
            if (ahead + i <= 14 && ahead - i >= 0)
            {
                if (pp[ahead + i] == true && pp[ahead - i] == true)
                {
                    return wall[ahead + i];
                }
                if (pp[ahead + i] == true)
                {
                    return wall[ahead + i];
                }
                if (pp[ahead - i] == true)
                {
                    return wall[ahead - i];
                }
            }
            else if (ahead - i >= 0)
            {
                if (pp[ahead - i] == true)
                {
                    return wall[ahead - i];
                }
            }
            else if (ahead + i <= 14)
            {
                if (pp[ahead + i] == true)
                {
                    return wall[ahead + i];
                }
            }
        }

        return 87;
    }

    void Start()
    {
        //--------------------------------------stytle
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[1];
        //--------------------------------------stytle
        enemy_position = transform.position;
    }

    void Update()
    {
        //--------------------------------------stytle
        if (health >= 66)
        {
            rend.sharedMaterial = materials[0];
        }
        else if (health >= 33)
        {
            rend.sharedMaterial = materials[1];
        }
        else
        {
            rend.sharedMaterial = materials[2];
        }
        //--------------------------------------stytle
        if (health <= 0)
        {
            die = true;
        }
        if (die == false)
        {
            if (Time.time - time >= speed_contral)
            {
                time = Time.time;
                if (dizzy == 0)
                {
                    if (enemy_position.y >= 3 || pass)
                    {
                        if (enemy_position.y >= 0)
                        {
                            pass = true;
                        }
                        else
                        {
                            pass = false;
                        }
                        //---------------------------------------------------------------------判斷哪裡可以走
                        if (nearest_entrance(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) != 87 && enemy_position.y >= 0.5f)
                        {
                            if (enemy_position.x - nearest_wall(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) >= -1 && enemy_position.x - nearest_wall(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) <= 1)
                            {
                                diract = 4;
                            }
                            else if (enemy_position.x - nearest_wall(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) > 1)
                            {
                                diract = 1;
                            }
                            else if (enemy_position.x - nearest_wall(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) < -1)
                            {
                                diract = 2;
                            }
                        }
                        else
                        {
                            diract = 3;
                        }
                    }
                    else
                    {
                        //---------------------------------------------------------------------判斷哪裡可以走
                        if (nearest_entrance(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) != 87)
                        {
                            if (enemy_position.x - nearest_entrance(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) >= -1 && enemy_position.x - nearest_entrance(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) <= 1)
                            {
                                diract = 3;
                            }
                            else if (enemy_position.x - nearest_entrance(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) > 1)
                            {
                                diract = 1;
                            }
                            else if (enemy_position.x - nearest_entrance(Wall_move.wall_p, enemy_position.x, Wall_move.wall_builded) < -1)
                            {
                                diract = 2;
                            }
                        }
                        else
                        {
                            diract = 6;
                        }
                    }
                    if (push > 0)
                    {
                        push--;
                        diract = 5;
                        if (push <= 3)
                        {
                            diract = 6;
                        }
                    }
                }
                else
                {
                    dizzy--;
                }
                if (dizzy <= 0 && push <= 0)
                {
                    tag = "Enemy_druger";
                }
                 //---------------------------------------------------------------------走
                if (dizzy == 0)
                {
                    if (diract == 1)
                    {
                        enemy_position.x -= step;
                    }
                    else if (diract == 2)
                    {
                        enemy_position.x += step;
                    }
                    else if (diract == 3)
                    {
                        enemy_position.y += step;
                    }
                    else if (diract == 4)
                    {
                        enemy_position.y -= step;
                    }
                    else if (diract == 5)
                    {
                        enemy_position.y -= 0.5f * push * step;
                    }
                }
            }

            transform.position = enemy_position;
        }
        else
        {
            if (size >= 2)
            {
                Destroy(gameObject);
            }
            transform.localScale -= new Vector3(s, s, s);
            size += s;

        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Bullet_p")
        {
            health -= 20;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Border")
        {
            if (push >= 3)
            {
                die = true;
            }
            if (diract == 1)
            {
                enemy_position.x -= step;
            }
            else if (diract == 2)
            {
                enemy_position.x -= step;
            }
            else
            {
                enemy_position.y -= step;
            }
        }
        if (other.gameObject.tag == "PPAP")
        {
            if (push >= 3)
            {
                die = true;
            }
            if (diract == 1)
            {
                enemy_position.x += step;
            }
            else if (diract == 2)
            {
                enemy_position.x += step;
            }
            else
            {
                enemy_position.y += 6*step;
                dizzy = 5;
            }
        }
        if (other.gameObject.tag == "Carried")
        {
            tag = "Enemy";
            if (Tump_move.move == 1)
            {
                dizzy = 1;
                enemy_position.x = Tump_move.Tump_position.x - 4.5f;
            }
            else if (Tump_move.move == 2)
            {
                dizzy = 1;
                enemy_position.x = Tump_move.Tump_position.x + 4.5f;
            }
            else if (Tump_move.move == 3)
            {
                dizzy = 1;
                enemy_position.y = Tump_move.Tump_position.y + 4f;
            }
            else if (Tump_move.move == 4)
            {
                if (push <= 15)
                {
                    push += 5;
                }
                dizzy = 1;
                enemy_position.y = Tump_move.Tump_position.y - 4f;
            }
            else
            {
                dizzy = 5;
                enemy_position.y = Tump_move.Tump_position.y - 3.5f;
            }
        }
        if (other.gameObject.tag == "Olt")
        {
            if (push <= 15)
            {
                push += 5;
            }
            dizzy = 1;
            enemy_position.y = other.transform.position.y - 4f;
        }
        if (other.gameObject.tag == "Stop")
        {
            transform.position = new Vector3(-200, 8, 76);
        }
    }
}
