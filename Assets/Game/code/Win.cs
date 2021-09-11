using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
    GUIStyle myStyle = new GUIStyle();
    // Use this for initialization
    int time;
    void Start()
    {
        time = (int)Time.time;
        myStyle.fontSize = 50;
        myStyle.normal.textColor = Color.white;//"A738F9FF";
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        if ((int)Time.time - time >= 3)
        {
            Destroy(GameObject.Find("jojo"));
            if (Tump_move.win)
            {
                GUI.Label(new Rect(350, 350, 200, 50), "You Win!", myStyle);
            }
        }
    }
}