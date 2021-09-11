using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Begin : MonoBehaviour {
    //GUI.Label(new Rect(50, 50, 200, 50), "You lose!");
    // Use this for initialization
    GUIStyle myStyle = new GUIStyle();
    Color a = new Color(147,250,245,255), b = new Color(253, 238, 119, 255);

    string[] story = new string[28];
    int i = 0,time = 2;
    float hight = 0,x = 5;
    public static bool started = false;
    void Start()
    {
        myStyle.fontSize = 25;

        story[0] = "Grandma?";
        story[1] = "Yes?";
        story[2] = "Can you tell me a bedside story?";
        story[3] = "Sure, how about the story of Trump?";
        story[4] = "Who's he?";
        story[5] = "Oh, he's one of the most famous heroes in our country.";
        story[6] = "What did he do?";
        story[7] = "No need to rush, my sweetheart.This story of the magnificent\n man has a normal beginning just like others:\n Long, long time ago, about the twenty first century...";
        story[8] = "Were you born yet?";
        story[9] = "No, sweetheart, As I told you,\nit was long, long time ago when Americans had hard times.\n'course we had a very, very bad neighbor called 'Mexico.'";
        story[10] = "People there were nothing more than\ndrug addicts, thieves, or murderers.\nAnd the only thing they knew was to smuggle \nillegal things to our country.";
        story[11] = "What we got in return was nothing but\npain, death, disease, and drug.\nOur people suffer from them for decades...";
        story[12] = "Oh, no.  That's terrible!";
        story[13] = "Yes, but don't worry.\nWhen we all thought there was no hope\n,our hero showed up...";
        story[14] = "It's Trump!";
        story[15] = "Yes, honey. It's Trump,\nHe pushed aside all obstacles and difficulties and \nbuilt a GREAT WALL! ";
        story[16] = "And with that we will get rid of those evil things, \nand become Greater and Greater... ";
        story[17] = "This is the story of Trump\n, our hero, our savior, the one,\nthe 45th President of the United States of America.";
        story[18] = " ";
        story[19] = ".";
        story[20] = ".   .";
        story[21] = ".   .   .";
        story[22] = "Press up,down,right,left, to move";
        story[23] = "Press Q to move wall";
        story[24] = "Press W to take gun";
        story[25] = "Press E to fire";
        story[26] = "Press R to  use Olt";
        story[27] = "Now are you ready to be the hero?!";
    }

    // Update is called once per frame
    void Update()
    {

        if (i <= 6)
        {
            if ((int)Time.time - time >= 2)
            {
                i++;
                time = (int)Time.time;
            }

        }
        else if(i <= 17)
        {
            if ((int)Time.time - time >= 4)
            {
                i++;
                time = (int)Time.time;
            }
        }
        else
        {
            if ((int)Time.time - time >= 2)
            {
                i++;
                time = (int)Time.time;
            }
        }
        if (i >= 28)
        {
            started = true;
        }
        x = 30;
        if (i >= 18)
        {
            myStyle.normal.textColor = Color.white;
            hight = 250;
            x = 250;
        }
        else if (i % 2 == 0 && i < 15 && i != 10)
        {
            myStyle.normal.textColor = Color.magenta;
            hight = 500;
        }
        else
        {
            myStyle.normal.textColor = Color.blue;
            hight = 10;
        }
    }
    void OnGUI()
    {
        if (Time.time >= 2)
        { 
            if (started)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                GUI.Label(new Rect(x, hight, 10, 10), story[i], myStyle);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            started = true;
        }
    }
}
