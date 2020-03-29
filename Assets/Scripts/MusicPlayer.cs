using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();

        audioSource.volume = PlayerPrefsController.MasterVolume;
    }

    public void SetVolume(float volume) => audioSource.volume = volume;
}
