﻿using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.playOnAwake = false;
        }

    }

    public void Play(string name, bool mindPlaying = false)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!mindPlaying)
            s.source.Play();
        else
            if(!s.source.isPlaying)
                s.source.Play();
    }
}