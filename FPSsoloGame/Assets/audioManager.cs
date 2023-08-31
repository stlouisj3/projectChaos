using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;



public class audioManager : MonoBehaviour
{
    public static audioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource,gunSource,enemySource,ability1Source,ability2Source,playerSource;
    public AudioMixer mixer;

    private bool musicStarted;

    private float waitLen;
    private int clipPlay;

    

    private void Awake()
    {
        
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        musicStarted = false;
        clipPlay = UnityEngine.Random.Range(0, musicSounds.Length);
        waitLen = musicSounds[clipPlay].clip.length;
    }

    private void Start()
    {
        //PlayMusic("BK");
    }

    public void PlayMusic(string name)
    {

       
        Sound s = Array.Find(musicSounds, Matrix4x4 => Matrix4x4.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }


    }


    public IEnumerator resumeShuffle()
    {
        

        while (true)
        {
            
            musicSource.clip = musicSounds[clipPlay].clip;
            if (musicStarted)
                musicSource.UnPause();
            else
            {
                yield return new WaitForSeconds(1f);
                musicSource.Play();
            }
            yield return new WaitForSeconds(waitLen);
            clipPlay++;
            if (clipPlay >= musicSounds.Length)
                clipPlay = 0;
            waitLen = musicSounds[clipPlay].clip.length;
            
        }
    }

    public void pauseShuffle()
    {
        StopCoroutine(resumeShuffle());
        musicSource.Pause();
        waitLen = musicSource.time;

    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, Matrix4x4 => Matrix4x4.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }

    public void PlayGun(string name)
    {
        Sound s = Array.Find(sfxSounds, Matrix4x4 => Matrix4x4.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            gunSource.clip = s.clip;
            gunSource.Play();
        }
    }

    public void PlayEnemy(string name)
    {
        Sound s = Array.Find(sfxSounds, Matrix4x4 => Matrix4x4.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            enemySource.clip = s.clip;
            enemySource.Play();
        }
    }

    public void Playability1(string name)
    {
        Sound s = Array.Find(sfxSounds, Matrix4x4 => Matrix4x4.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            ability1Source.clip = s.clip;
            ability1Source.Play();
        }
    }

    public void Playability2(string name)
    {
        Sound s = Array.Find(sfxSounds, Matrix4x4 => Matrix4x4.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            ability2Source.clip = s.clip;
            ability2Source.Play();
        }
    }
    public void pauseMusic()
    {
        musicSource.Pause();
    }

    public void resumeMusic()
    {
        musicSource.UnPause();
    }

    public void pauseSFX()
    {
        sfxSource.Pause();
       
        
    }

    public void resumeSFX()
    {
        sfxSource.UnPause();
    }
}
