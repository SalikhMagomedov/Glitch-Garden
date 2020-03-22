using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private int lives = 5;

    TMPro.TextMeshProUGUI livesText;

    private void Start()
    {
        livesText = GetComponent<TMPro.TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay() => livesText.text = lives.ToString();

    public void TakeLife()
    {
        lives--;
        UpdateDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }
}
