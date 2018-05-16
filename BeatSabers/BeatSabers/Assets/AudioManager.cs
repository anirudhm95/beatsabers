//using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {


    public Sounds[] sounds;
    public Sounds[] orbSounds;
    public Sounds[] music;

    public string musicName;
    public AudioHelm.AudioHelmClock clock;
    float timeOffset;
    // Use this for initialization
    void Awake () {
        clock = FindObjectOfType<AudioHelm.AudioHelmClock>();
        clock.bpm = SaveData.createGameData.bpm; 
        foreach (Sounds s in music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        foreach (Sounds s in orbSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        if (clock.bpm == 163) { timeOffset = 280f; }
        else { timeOffset = 240f; }

        Invoke("PlayMusic", timeOffset / clock.bpm);
    }

    private void Start()
    {
    }

    public void PlayMusic()
    {
        //music[1].source.Play();
        music[SaveData.createGameData.songIndex].source.Play();
    }

    public void Play (string name)
    {
        Sounds s = Array.Find(sounds, Sounds => Sounds.name == name);
        s.source.PlayScheduled(500);
    }

    public void Pause()
    {
        music[1].source.Pause();
    }

    public void UnPause()
    {
        music[1].source.Play();
    }
}
