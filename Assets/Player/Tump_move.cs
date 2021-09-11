using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Tump_move : MonoBehaviour
{
    public static bool boss_died = false;
    public static Vector3 Tump_position;
    //public Vector3 Tump_size;
    float time = -40;
    bool pressedR = false;
    public static int move = 0;
    int movel = 0, mover = 0, moveu = 0, moved = 0;
    public float step = 0.33f;
    public float speed_contral;
    float olt_cd = 0,olt_p=0;
    public static int health = 100;
    public static int san = 0;
    public static bool lose = false, win = false;

    string s="8787";

    void Start()
    {
        Tump_position = transform.position;
        //Tump_size = boxCollider.size;

    }

    void Update()
    {
        if (boss_died && Wall_move.all_builed)
        {
            win = true;
        }
        //---------------------------------------------------R
        if (Time.time - olt_cd >= 40)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                pressedR = true;
            }
        }
        else
        {
            pressedR = false;
        }

        if (pressedR)
        {
            Instantiate(GameObject.Find("Olt"), new Vector3(4, 30, 75), GameObject.Find("Olt").transform.rotation);
            olt_cd = Time.time;
        }
        //---------------------------------------------------R
        //speed_contral += san;
        //------------------
        if (health <= 0)
        {
            lose = true;
        }
        //------------------
        if (Time.time - time >= speed_contral)
        {
            time = Time.time;

            if (Input.GetKey(KeyCode.LeftArrow) && movel == 0)
            {
                Tump_position.x -= step;
                move = 1;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && mover == 0)
            {
                Tump_position.x += step;
                move = 2;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && moveu == 0)
            {
                Tump_position.y += step;
                move = 3;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && moved == 0)
            {
                Tump_position.y -= step;
                move = 4;
            }
            else
            {
                move = 5;
            }
        }
        if (movel != 0)
        {
            movel--;
        }
        if (mover != 0)
        {
            mover--;
        }
        if (moveu != 0)
        {
            moveu--;
        }
        if (moved != 0)
        {
            moved--;
        }
        if (Tump_position.y <= 0.7f)
        {
            Tump_position.y = 1.2f;
        }
        transform.position = Tump_position;
    }
    void OnTriggerEnter(Collider other)
    {
        //-------------------------------------------對PPAP的碰撞處理

        if (other.gameObject.tag == "Border" || other.gameObject.tag == "PPAP" || other.gameObject.tag == "mid")
        {
            if (move == 1)
            {
                Tump_position.x += step;
                movel = 10;
            }
            else if (move == 2)
            {
                Tump_position.x -= step;
                mover = 10;
            }
            else if (move == 3)
            {
                Tump_position.y -= step;
                moveu = 10;
            }
            else if (move == 4)
            {
                Tump_position.y += step;
                moved = 10;
            }
        }
        //-------------------------------------------對Enemy的碰撞處理
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy_druger")
        {
            health -= 3;
            if (move == 1)
            {
                Tump_position.x += 2 * step;
                movel = 10;
            }
            else if (move == 2)
            {
                Tump_position.x -= 2 * step;
                mover = 10;
            }
            else if (move == 3)
            {
                Tump_position.y -= 2 * step;
                moveu = 10;
            }
            else if (move == 4)
            {
                Tump_position.y += 2 * step;
                moved = 10;
            }
            else
            {
                Tump_position.y += 2 * step;
            }
        }
        if (other.gameObject.tag == "Bullet_e")
        {
            health -= 5;
            Destroy(other.gameObject);
        }
    }
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 25;
        myStyle.normal.textColor = Color.white;//"A738F9FF";
        s = "Health: " + health;
        GUI.Label(new Rect(10, 10, 200, 50), s,myStyle);

        if (lose)
        {
            SceneManager.LoadScene(3);
        }
        if (win)
        {
            SceneManager.LoadScene(2);
        }
        if (!Begin.started)
        {
            SceneManager.LoadScene(0);
        }
    }
}
