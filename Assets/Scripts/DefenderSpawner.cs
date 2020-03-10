using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defenderPrefab;

    private void OnMouseDown() => SpawnDefender(GetSquareClicked());

    private Vector2 GetSquareClicked()
    {
        var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private void SpawnDefender(Vector2 squarePosition)
    {
        var newDefender = Instantiate(defenderPrefab, squarePosition, Quaternion.identity);
    }
}
