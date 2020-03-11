using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Defender defenderPrefab;

    private SpriteRenderer spriteRenderer;
    private DefenderSpawner defenderSpawner;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(25, 25, 25, 255);
        }
        spriteRenderer.color = Color.white;
        defenderSpawner.SelectedDefender = defenderPrefab;
    }
}
