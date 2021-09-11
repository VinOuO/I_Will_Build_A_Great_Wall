using UnityEngine;
using System.Collections;

public class bullet_move2 : MonoBehaviour {
    Vector3 bullet_p_position;
    public static int speed=2000;
    bool first = false;
    //--------------------------------------audio
    //public AudioClip clips;
    //private AudioSource audio;
    //--------------------------------------audio
    // Use this for initialization
    void Start () {
        bullet_p_position.x = 0;
        bullet_p_position.y = -0.5f;
        bullet_p_position.z = 0;
        //--------------------------------------audio
        //audio = GetComponent<AudioSource>();
        //audio.PlayOneShot(clips, 0.7F);
        //--------------------------------------audio
    }

    // Update is called once per frame
    void Update () {
        transform.position += speed * bullet_p_position * Time.deltaTime / 50;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "border")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Stop")
        {
            transform.position = new Vector3(-200, 8, 76);
        }
    }
}
