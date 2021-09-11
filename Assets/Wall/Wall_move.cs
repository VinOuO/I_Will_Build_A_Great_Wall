using UnityEngine;
using System.Collections;

public class Wall_move : MonoBehaviour
{
    //--------------------------------------stytle
    public Material[] materials;
    Renderer rend;
    //--------------------------------------stytle

    //--------------------------------------audio
    public AudioClip[] clips = new AudioClip[2];
    private AudioSource audio;
    //float start = 0, end = 0;
    //--------------------------------------audio

    //public static bool Q;
    public GameObject target;
    Vector3 wall_position;
    Vector3 enemy_position;
    bool target_carried = false, carriable = true,first = true;
    int wall_num = 1;
    public static bool[] wall_builded = new bool[15] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };  //-47,-41,-35,-29,-23,-17,-11,-5,1,7,13,19,25,31,37
    public static int[] wall_p = new int[15] { -47, -41, -35, -29, -23, -17, -11, -5, 1, 7, 13, 19, 25, 31, 37 };
    int pos;
    float p;
    int loc = 0;
    int health = 100;
    public static bool all_builed = false;

    private void Start()
    {
        //--------------------------------------stytle
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[1];
        //--------------------------------------stytle

        //--------------------------------------audio
        audio = GetComponent<AudioSource>();
        //--------------------------------------audio
        wall_position = transform.position;
    }


    private void Update()
    {
        all_builed = true;
        for (int i = 0; i <= 14; i++)
        {
            if (!wall_builded[i])
            {
                all_builed = false;
            }
        }
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

        if (target.transform.position.x - transform.position.x <= 2 && target.transform.position.y - transform.position.y <= 2 && target.transform.position.x - transform.position.x >= -2 && target.transform.position.y - transform.position.y >= -2)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (carriable)
                {
                    if (target_carried)
                    {
                        target_carried = false;
                        tag = "PPAP";
                        //Q = false;
                        for (int i = 0; i < 15; i++)
                        {
                            p = wall_p[i] - transform.position.x;
                            if (p < 0)
                            {
                                p = -p;
                            }
                            if (p <= 3)
                            {
                                loc = i;
                                break;
                            }
                        }
                        if (transform.position.y < 1f && transform.position.y > -1f && !wall_builded[loc])
                        {
                            //--------------------------------------audio
                            if (!audio.isPlaying)
                            {
                                if(Random.Range(0, 2) == 0)
                                {
                                    audio.PlayOneShot(clips[0], 0.4F);
                                    //start = Time.time;
                                    //end = 3;
                                }
                                else
                                {
                                    audio.PlayOneShot(clips[1], 0.35F);
                                    //start = Time.time;
                                    //end = 13;
                                }
                            }
                            //--------------------------------------audio
                            wall_num = 0;
                            wall_position.y = 0;
                            wall_position.x = wall_p[loc];
                            pos = loc;
                            wall_builded[loc] = true;
                        }
                    }
                    else
                    {
                        target_carried = true;
                        first = false;
                        tag = "Carried";
                        //Q = true;
                    }
                }
            }
        }
        if (target_carried)
        {
            transform.position = target.transform.position;
            wall_position = transform.position;
            wall_position.y -= 1.7f;
        }
        if(wall_num == 0)
        {
            Instantiate(this, new Vector3(-3 , 2.5f, 75), transform.rotation);
            wall_num = 1;
            carriable = false;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            wall_builded[pos] = false;
        }

        transform.position = wall_position;
    }
    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Enemy")
        {
            enemy_position = other.gameObject.transform.position;
            
            if (Enemy_normal_move.diract == 1)
            {
                enemy_position.x -= Enemy_normal_move.step;
            }
            else if (Enemy_normal_move.diract == 2)
            {
                enemy_position.x -= Enemy_normal_move.step;
            }
            else
            {
                enemy_position.y -= Enemy_normal_move.step;
            }
        }
        other.gameObject.transform.position = enemy_position;*/
        if (other.gameObject.tag == "Enemy_druger")
        {
            if(this.tag!="Carried" && !first)
            health -= 10;
        }
        if (other.gameObject.tag == "Bomb")
        {
            if (this.tag != "Carried" && !first)
                health -= 100;
        }
    }
}