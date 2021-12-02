using RestClient.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    AudioSource[] sounds;
    protected override void Awake()
    {
        sounds = GetComponents<AudioSource>();
    }

}
