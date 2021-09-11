using UnityEngine;
using System.Collections;

public class aaa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Enemy_boss.summoned)
        {
            Destroy(gameObject);
        }
	}
}
