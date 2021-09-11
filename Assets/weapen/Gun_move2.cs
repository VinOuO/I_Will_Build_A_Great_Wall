using UnityEngine;
using System.Collections;

public class Gun_move2 : MonoBehaviour {
    bool carriable = true, target_carried = false, load = false;
    Vector3 p;
    float q;
    public GameObject target;
    Vector3 gun_p_position;
    int x;

    // Use this for initialization
    void Start () {
        gun_p_position = transform.position;
        p.x = 0;
        p.y = -1;
        p.z = 0;
        InvokeRepeating("shoot", 0, 0.25f);
    }

    void shoot()
    {
        //-------------------------------------------------------------子彈射擊
        if (Input.GetKey(KeyCode.E) && target_carried)
        {
            Instantiate(GameObject.Find("bullet_p"), GameObject.Find("Tump").transform.position + new Vector3(1.5f, -3f, 0), GameObject.Find("bullet_p").transform.rotation);
        }
        if (load)
        {
            Instantiate(GameObject.Find("bullet_p"), this.transform.position + new Vector3(0, -3f, 0), GameObject.Find("bullet_p").transform.rotation);
        }
    }
        // Update is called once per frame
        void Update()
    {
        if (!Wall_move.wall_builded[x])
        {
            load = false;
            carriable = true;
        }
        if (target.transform.position.x - transform.position.x <= 2 && target.transform.position.y - transform.position.y <= 4 && target.transform.position.x - transform.position.x >= -2 && target.transform.position.y - transform.position.y >= -2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (carriable)
                {
                    if (target_carried)
                    {
                        target_carried = false;
                        if (transform.position.y < 2f && transform.position.y > -0.5f)
                        {
                            for (int i = 0; i < 15; i++)
                            {
                                q = Wall_move.wall_p[i] - transform.position.x;
                                if (q < 0)
                                {
                                    p = -p;
                                }
                                if (q <= 3)
                                {
                                    if (Wall_move.wall_builded[i])
                                    {
                                        x = i;
                                        carriable = false;
                                        load = true;
                                        gun_p_position.x = Wall_move.wall_p[i];
                                        gun_p_position.y = -0.5f;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        target_carried = true;
                    }
                }
            }
        }
        
        if (target_carried)
        {
            transform.position = target.transform.position;
            gun_p_position = transform.position;
            gun_p_position.y -= 0.3f;
            gun_p_position.x += 1.5f;
        }
        transform.position = gun_p_position;
    }
}
