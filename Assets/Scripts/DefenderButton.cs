using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(25, 25, 25, 255);
        }
        spriteRenderer.color = Color.white;
    }
}
