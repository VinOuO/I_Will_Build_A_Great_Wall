using UnityEngine;
using System.Collections;

public class Olt_move : MonoBehaviour {
    //Vector3 Olt_position;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, -0.1f, 0);
        //Olt_position = transform.position;
        if (transform.position.y <= -40)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            transform.position = new Vector3(-300, 17, 76);
        }
    }
}

