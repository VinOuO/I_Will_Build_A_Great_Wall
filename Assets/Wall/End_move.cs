using UnityEngine;
using System.Collections;

public class End_move : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy_druger")
        {
            Tump_move.health-=10;
            Destroy(other.gameObject);
        }
    }
}
