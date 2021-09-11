using UnityEngine;
using System.Collections;

public class Tump_buildwall : MonoBehaviour {

    public GameObject target;
    Vector3 wall_position;
    bool target_carried = false;
    
    private void Start()
    {
        
    }


    private void Update()
    {
        if(target.transform.position.x-transform.position.x<=2 && target.transform.position.y - transform.position.y <= 2 && target.transform.position.x - transform.position.x >= -2 && target.transform.position.y - transform.position.y >= -2)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (target_carried)
                {
                    target_carried = false;
                }
                else{
                    target_carried = true;
                }
            }
        }
        if (target_carried)
        {
            target.transform.position = transform.position;
            wall_position = target.transform.position;
            wall_position.y -= 0.5f;
            target.transform.position = wall_position;
        } 
    }
}