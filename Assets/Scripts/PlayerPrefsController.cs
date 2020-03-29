using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "master volume";
    private const string DIFFICULTY_KEY = "difficulty";

    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;

    public static float MasterVolume
    {
        get => PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        set
        {
            if (value >= MIN_VOLUME || value <= MAX_VOLUME)
            {
                Debug.Log($"Master volume set to {value}.");
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
            }
            else
            {
                Debug.LogError("Master volume is out of range");
            }
        }
    }
}
