using System;
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
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        var costText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (!costText)
        {
            Debug.LogError($"{name} has no cost text, add some!");
        }
        else
        {
            costText.text = defenderPrefab.StarCost.ToString();
        }
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
