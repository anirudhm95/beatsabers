//using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {


    public Sounds[] sounds;

	// Use this for initialization
	void Awake () {
		
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
	}

    private void Start()
    {
        Play("Theme");
    }

    public void Play (string name)
    {
        Sounds s = Array.Find(sounds, Sounds => Sounds.name == name);
        s.source.PlayScheduled(500);
    }
}
