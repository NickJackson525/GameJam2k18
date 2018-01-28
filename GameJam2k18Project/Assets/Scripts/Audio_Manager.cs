
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

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
        {Sound.Victory, Resources.Load<AudioClip>("Sounds/Victory")},
        {Sound.Shoot, Resources.Load<AudioClip>("Sounds/Shoot_laser")},
        {Sound.Background1, Resources.Load<AudioClip>("Sounds/Beat1")},
        {Sound.Background2, Resources.Load<AudioClip>("Sounds/Beat2")},
        {Sound.ThemeSong, Resources.Load<AudioClip>("Sounds/ThemeSong")},
        {Sound.ButtonHover, Resources.Load<AudioClip>("Sounds/ButtonHover")},
        {Sound.ButtonClick, Resources.Load<AudioClip>("Sounds/ButtonClick")},
    };

    public enum Sound { Turret1, Turret2, Turret3, Turret4, Turret5, Turret6, Turret7, Turret8, Turret9, Searching, Vaccuum, GameOver, Victory, Shoot, Background1, Background2, ThemeSong, ButtonHover, ButtonClick }

    public GameObject source;
    public GameObject backroundSource;

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

    #region Update

    public void Update()
    {
        if (backroundSource == null)
        {
            backroundSource = GameObject.Find("BackgroundSource");
        }

        if (!backroundSource.GetComponent<AudioSource>().isPlaying)
        {
            PlayBackgroundMusic();
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

    public void PlaySound(float volume, Sound soundToPlay)
    {
        if (source == null)
        {
            source = GameObject.Find("AudioSource");
        }

        source.GetComponent<AudioSource>().PlayOneShot(SoundClips[soundToPlay], volume);
    }

    public void PlaySound(AudioSource targetSource, Sound soundToPlay)
    {
        if (source == null)
        {
            source = GameObject.Find("AudioSource");
        }

        targetSource.GetComponent<AudioSource>().PlayOneShot(SoundClips[soundToPlay], 1f);
    }

    public void PlayBackgroundMusic()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            backroundSource.GetComponent<AudioSource>().Stop();
            backroundSource.GetComponent<AudioSource>().PlayOneShot(SoundClips[Sound.ThemeSong], .6f);
        }
        else
        {
            backroundSource.GetComponent<AudioSource>().Stop();
            int rand = UnityEngine.Random.Range(0, 2);

            switch (rand)
            {
                case 0:
                    backroundSource.GetComponent<AudioSource>().PlayOneShot(SoundClips[Sound.Background1], 3f);
                    break;
                case 1:
                    backroundSource.GetComponent<AudioSource>().PlayOneShot(SoundClips[Sound.Background2], 3f);
                    break;
                default:
                    backroundSource.GetComponent<AudioSource>().PlayOneShot(SoundClips[Sound.Background1], 3f);
                    break;
            }
        }
    }

    #endregion
}