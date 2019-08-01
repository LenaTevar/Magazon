using System;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void play(string title)
    {
        Sound s = Array.Find(sounds, sound => sound.name == title);
      
        if(s == null)
        {
            Debug.Log(">> Sound " + title + " not found.");
            return;
        }
        s.source.Play();
    }
}
