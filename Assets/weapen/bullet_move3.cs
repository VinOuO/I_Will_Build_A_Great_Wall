using UnityEngine;
using System.Collections;

public class bullet_move3 : MonoBehaviour
{
    Vector3 bullet_p_position;
    public static int speed = 2000;
    bool first = false;

    void Start()
    {
        bullet_p_position.x = 0;
        bullet_p_position.y = 0.5f;
        bullet_p_position.z = 0;
    }

    void Update()
    {
        transform.position += speed * bullet_p_position * Time.deltaTime / 75;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Carried")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Stop")
        {
            transform.position = new Vector3(-200, 8, 76);
        }
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}