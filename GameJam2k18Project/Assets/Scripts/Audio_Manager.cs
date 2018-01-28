
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Audio_Manager
{
    #region Variables

    public Dictionary<Sound, AudioClip> SoundClips = new Dictionary<Sound, AudioClip>
    {
        {Sound.Turret1, Resources.Load<AudioClip>("Sounds/ShieldTurret-BringMeYourTeddyBears")},
        {Sound.Turret2, Resources.Load<AudioClip>("Sounds/ShieldTurret-ConsiderLerping")},
        {Sound.Turret3, Resources.Load<AudioClip>("Sounds/ShieldTurret-FuckTheMainstream")},
        {Sound.Turret4, Resources.Load<AudioClip>("Sounds/ShieldTurret-IAmShieldTurret")},
        {Sound.Turret5, Resources.Load<AudioClip>("Sounds/ShieldTurret-IAmTheSenate")},
        {Sound.Turret6, Resources.Load<AudioClip>("Sounds/ShieldTurret-Initialized")},
        {Sound.Turret7, Resources.Load<AudioClip>("Sounds/ShieldTurret-404")},
        {Sound.Turret8, Resources.Load<AudioClip>("Sounds/ShieldTurret-CommentYourCode")},
        {Sound.Turret9, Resources.Load<AudioClip>("Sounds/ShieldTurret-RTFS")},
        {Sound.Searching, Resources.Load<AudioClip>("Sounds/Searching")},
        {Sound.Vaccuum, Resources.Load<AudioClip>("Sounds/Vaccuum")},
        {Sound.GameOver, Resources.Load<AudioClip>("Sounds/GameOver")},
        {Sound.Shoot, Resources.Load<AudioClip>("Sounds/Shoot_laser")},
    };

    public enum Sound { Turret1, Turret2, Turret3, Turret4, Turret5, Turret6, Turret7, Turret8, Turret9, Searching, Vaccuum, GameOver, Shoot }

    public GameObject source;

    #endregion

    #region Singleton

    // create variable for storing singleton that any script can access
    private static Audio_Manager instance;

    // create AudioManager
    private Audio_Manager()
    {

    }

    // Property for Singleton
    public static Audio_Manager Instance
    {
        get
        {
            // If the singleton does not exist
            if (instance == null)
            {
                // create and return it
                instance = new Audio_Manager();
            }

            // otherwise, just return it
            return instance;
        }
    }

    #endregion

    #region Play Sounds

    public void PlaySound(Sound soundToPlay)
    {
        if(source == null)
        {
            source = GameObject.Find("AudioSource");
        }

        source.GetComponent<AudioSource>().PlayOneShot(SoundClips[soundToPlay], 1f);
    }

    public void PlaySound(AudioSource targetSource, Sound soundToPlay)
    {
        if (source == null)
        {
            source = GameObject.Find("AudioSource");
        }

        targetSource.GetComponent<AudioSource>().PlayOneShot(SoundClips[soundToPlay], 1f);
    }

    #endregion
}