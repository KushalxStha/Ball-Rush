using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bgm;

    void Start()
    {
        // Set the volume level of the BGM based on the saved setting
        bgm.volume = PlayerPrefs.GetFloat("BGMVolume", 1f);
    }
    private void Update()
    {
        if (bgm != null)
        {
            // To adjust Pitch
            if (Input.GetKeyDown(KeyCode.I)) bgm.pitch += 0.1f;
            if (Input.GetKeyDown(KeyCode.K)) bgm.pitch -= 0.1f;

            // To adjust Volume
            if (Input.GetKeyDown(KeyCode.L)) bgm.volume += 0.1f;
            if (Input.GetKeyDown(KeyCode.J)) bgm.volume -= 0.1f;

            // Clamping values to avoid out-of-range errors
            bgm.pitch = Mathf.Clamp(bgm.pitch, 0.1f, 3f);
            bgm.volume = Mathf.Clamp(bgm.volume, 0f, 1f);
        }

        if (Time.timeScale == 1f && !bgm.isPlaying)
        {
            bgm.Play();
        }
        else if (Time.timeScale == 0f && bgm.isPlaying)
        {
            bgm.Pause();
        }
    }
}