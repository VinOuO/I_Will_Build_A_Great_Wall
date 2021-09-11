using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {
    GUIStyle myStyle = new GUIStyle();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        myStyle.fontSize = 50;
        myStyle.normal.textColor = Color.white;//"A738F9FF";
        if (Tump_move.lose)
        {
            GUI.Label(new Rect(350, 350, 200, 50), "You Lose!", myStyle);
        }
    }
}
