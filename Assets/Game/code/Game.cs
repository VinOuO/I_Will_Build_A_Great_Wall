using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    //int i = Random.Range(0, 10);
    //float f = Random.Range(0.0f, 10.0f);
    bool sum = false;

    void creatEnemy()
    {
        if (!Enemy_boss.summoned)
        {
            int n = Random.Range(0, 3);
            Vector3 random_position;
            random_position.x = Random.Range(-46, 36);
            random_position.y = -40;
            random_position.z = 75.5f;
            if (n == 0)
            {
                Instantiate(GameObject.Find("Enemy_normal"), random_position, GameObject.Find("Enemy_normal").transform.rotation);
            }
            else if (n == 1)
            {
                Instantiate(GameObject.Find("Enemy_druger"), random_position, GameObject.Find("Enemy_druger").transform.rotation);
            }
            else if (n == 2)
            {
                Instantiate(GameObject.Find("Enemy_gangster"), random_position, GameObject.Find("Enemy_gangster").transform.rotation);
            }
        }
        else
        {
            int n = Random.Range(0, 6);
            Vector3 random_position;
            random_position.x = Random.Range(-46, 36);
            random_position.y = -40;
            random_position.z = 75.5f;
            if (n == 0)
            {
                Instantiate(GameObject.Find("Enemy_normal"), random_position, GameObject.Find("Enemy_normal").transform.rotation);
            }
            else if (n == 1)
            {
                Instantiate(GameObject.Find("Enemy_druger"), random_position, GameObject.Find("Enemy_druger").transform.rotation);
            }
            else if (n == 2)
            {
                Instantiate(GameObject.Find("Enemy_gangster"), random_position, GameObject.Find("Enemy_gangster").transform.rotation);
            }
        }
    }

    void Start()
    {
        Random.seed = System.Guid.NewGuid().GetHashCode();
        InvokeRepeating("creatEnemy", 1f, 3f);
    }

    void Update()
    {
        //Instantiate(GameObject.Find("Healthbar"), transform.position, transform.rotation);
    }
}
