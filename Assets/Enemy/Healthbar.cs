using UnityEngine;
using System.Collections;

public class Healthbar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Instantiate(GameObject.Find("Healthbar"), transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
