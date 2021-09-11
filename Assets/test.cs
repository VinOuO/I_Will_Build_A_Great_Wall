using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class test : MonoBehaviour
{
    public AudioClip[] clips = new AudioClip[2];
    private AudioSource[] audio = new AudioSource[2];
    void Start()
    {
        audio[1] = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audio[0].PlayOneShot(clips[0], 0.7F);
    }
}