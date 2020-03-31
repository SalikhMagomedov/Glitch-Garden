using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defenderPrefab;
    private GameObject defenderParent;

    private const string DEFENDER_PARENT_NAME = "Defenders";

    private void Awake()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown() => AttemptToPlaceDefenderAt(GetSquareClicked());

    private Vector2 GetSquareClicked()
    {
        var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var worldPos = Camera.main.ScreenToWorldPoint(clickPos);

        return SnapToGrid(worldPos);
    }

    public Defender SelectedDefender { set => defenderPrefab = value; }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition) => new Vector2(
        Mathf.RoundToInt(rawWorldPosition.x),
        Mathf.RoundToInt(rawWorldPosition.y));

    private void SpawnDefender(Vector2 position)
    {
        var newDefender = Instantiate(defenderPrefab, position, Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        if (defenderPrefab == null) { return; }

        var starDisplay = FindObjectOfType<StarDisplay>();
        var defenderCost = defenderPrefab.StarCost;

        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }
}
