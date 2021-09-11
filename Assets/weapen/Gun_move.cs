using UnityEngine;
using System.Collections;

public class Gun_move : MonoBehaviour {
    Quaternion gun_rotation;
    public static Vector3 gun_position;
    Vector3 bullet_p , gun1_position, gun2_position;
    public int time_contral = 2100000000;
    int time = 0;
    float angle_t_g;

    void shoot()
    {
        //-------------------------------------------------------------子彈射擊
        if (Tump_move.Tump_position.y - transform.position.y >= 0)
        {
            Instantiate(GameObject.Find("bullet"), this.gameObject.transform.GetChild(2).position, GameObject.Find("bullet").transform.rotation);
        }
    }

    void Start () {
        InvokeRepeating("shoot", 1f, 1.5f);
    }

	void Update () {
        gun_position = transform.position;
        //-------------------------------------------------------------設定槍面朝玩家
        gun1_position = this.gameObject.transform.GetChild(0).position;
        gun2_position = this.gameObject.transform.GetChild(1).position;
        angle_t_g= Mathf.Atan((Tump_move.Tump_position.x - transform.position.x) / (Tump_move.Tump_position.y - transform.position.y)) - Mathf.Atan((gun1_position.x - gun2_position.x) / (gun1_position.y - gun2_position.y));
        if (angle_t_g > Mathf.PI)
        {
            angle_t_g -= Mathf.PI;
        }
        if (Tump_move.Tump_position.y - transform.position.y >= 0)
        {
            if (angle_t_g > Mathf.PI / 18)
            {
                transform.Rotate(-1, 0, 0);
            }
            if (angle_t_g < -Mathf.PI / 18)
            {
                transform.Rotate(1, 0, 0);
            }
        }

    }
}
