using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private float defaultVolume = .8f;
    [SerializeField] private float defaultDifficulty = 0f;

    private MusicPlayer musicPlayer;

    private void Awake()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.MasterVolume;
        difficultySlider.value = PlayerPrefsController.Difficulty;
    }

    private void Update()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found... did you start from splash screen?");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.MasterVolume = volumeSlider.value;
        PlayerPrefsController.Difficulty = difficultySlider.value;
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
