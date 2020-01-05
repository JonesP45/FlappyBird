using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//permet de jouer differents sons
public class SoundAction : MonoBehaviour
{
    public AudioClip hit;
    public AudioClip die;
    public AudioClip point;
    public AudioClip fly;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playSoundHit()
    {
        source.clip = hit;
        source.PlayOneShot(source.clip);
    }

    public void playSoundDie()
    {
        source.clip = die;
        source.PlayOneShot(source.clip);
    }

    public void playSoundPoint()
    {
        source.clip = point;
        source.PlayOneShot(source.clip);
    }
    public void playSoundFlying()
    {
        source.clip = fly;
        source.PlayOneShot(source.clip);
    }
}
