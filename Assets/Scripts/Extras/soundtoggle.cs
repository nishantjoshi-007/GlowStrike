using UnityEngine;
using UnityEngine.UI;

public class SoundAndImageToggleManager : MonoBehaviour
{
    private Backgroundmusic backgroundMusic; // Reference to Backgroundmusic script

    // UI elements and sprites for toggling
    public Image musicToggleImage;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    public Image soundEffectsToggleImage;
    public Sprite soundEffectsOnSprite;
    public Sprite soundEffectsOffSprite;

    void Start()
    {
        // Find the Backgroundmusic instance in the scene
        backgroundMusic = FindObjectOfType<Backgroundmusic>();
        if (backgroundMusic == null)
        {
            Debug.LogError("Backgroundmusic instance not found in the scene.");
        }

        UpdateMusicToggleImage();
        UpdateSoundEffectsToggleImage();
    }

    public void ToggleBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.ToggleBackgroundMusic();
            UpdateMusicToggleImage();
        }
    }

    public void ToggleSoundEffects()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.ToggleSoundEffects();
            UpdateSoundEffectsToggleImage();
        }
    }

    private void UpdateMusicToggleImage()
    {
        if (musicToggleImage != null)
        {
            musicToggleImage.sprite = backgroundMusic.IsMusicPlaying() ? musicOnSprite : musicOffSprite;
        }
    }

    private void UpdateSoundEffectsToggleImage()
    {
        if (soundEffectsToggleImage != null)
        {
            soundEffectsToggleImage.sprite = Backgroundmusic.playSoundEffects ? soundEffectsOnSprite : soundEffectsOffSprite;
        }
    }
}