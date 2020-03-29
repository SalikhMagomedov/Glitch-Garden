using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "master volume";
    private const string DIFFICULTY_KEY = "difficulty";

    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;

    private const float MIN_DIFFICULTY = 0f;
    private const float MAX_DIFFICULTY = 1f;

    public static float MasterVolume
    {
        get => PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        set
        {
            if (value >= MIN_VOLUME && value <= MAX_VOLUME)
            {
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
            }
            else
            {
                Debug.LogError("Master volume is out of range");
            }
        }
    }

    public static float Difficulty
    {
        get => PlayerPrefs.GetFloat(DIFFICULTY_KEY);
        set
        {
            if (value >= MIN_DIFFICULTY && value <= MAX_DIFFICULTY)
            {
                PlayerPrefs.SetFloat(DIFFICULTY_KEY, value);
            }
            else
            {
                Debug.LogError("Difficulty setting not in range");
            }
        }
    }
}
