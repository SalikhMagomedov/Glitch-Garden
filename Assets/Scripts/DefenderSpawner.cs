using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defenderPrefab;

    private void OnMouseDown() => SpawnDefender(GetSquareClicked());

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
    }
}
