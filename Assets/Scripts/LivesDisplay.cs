using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;

    private float lives;
    private TextMeshProUGUI livesText;

    private void Start()
    {
        lives = baseLives - PlayerPrefsController.Difficulty;
        livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay() => livesText.text = lives.ToString();

    public void TakeLife()
    {
        lives--;
        UpdateDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
