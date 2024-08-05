using UnityEngine;
using UnityEngine.UIElements;

public class BgmController : MonoBehaviour
{
    [SerializeField]
    public Slider volumeSlider;
    public AudioSource bgm;

    private void Start()
    {
        if (volumeSlider == null)
        {
            Debug.Log("Volume Slider is not assigned.");
            return;
        }

        if (bgm == null)
        {
            Debug.Log("BGM AudioSource is not assigned.");
            return;
        }
        // Load the volume setting from PlayerPrefs and set the slider value
        volumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        // Ensure the BGM volume is set based on saved preferences
        bgm.volume = volumeSlider.value;
    }

    public void OnVolumeChanged(float volume)
    {
        // Save the volume setting to PlayerPrefs
        PlayerPrefs.SetFloat("BGMVolume", volume);
        // Apply the volume setting to the BGM in real-time
        bgm.volume = volume;
        
        if (!bgm.isPlaying)
        {
            bgm.Play();
        }
    }
}