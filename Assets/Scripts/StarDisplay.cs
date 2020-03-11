using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 100;

    private TextMeshProUGUI starText;

    private void Awake() => starText = GetComponent<TextMeshProUGUI>();

    private void Start() => UpdateDisplay();

    private void UpdateDisplay() => starText.text = stars.ToString();

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars < amount) { return; }

        stars -= amount;
        UpdateDisplay();
    }
}
