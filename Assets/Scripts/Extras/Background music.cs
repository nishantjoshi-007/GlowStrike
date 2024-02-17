using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmusic : MonoBehaviour
{
    private static Backgroundmusic backgroundmusic;
    private AudioSource audioSource;
    public static bool playSoundEffects = true;

    void Awake()
    {
        if (backgroundmusic == null)
        {
            backgroundmusic = this;
            DontDestroyOnLoad(backgroundmusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsMusicPlaying()
    {
        return audioSource.isPlaying;
    }

    public void ToggleBackgroundMusic()
    {
        Debug.Log("Current audio state before toggle: " + audioSource.isPlaying);
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
        Debug.Log("New audio state after toggle: " + audioSource.isPlaying);
    }

    public void ToggleSoundEffects()
    {
        playSoundEffects = !playSoundEffects;
    }
}
