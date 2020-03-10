using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defenderPrefab;

    private void OnMouseDown() => SpawnDefender();

    private void SpawnDefender()
    {
        var newDefender = Instantiate(defenderPrefab, transform.position, Quaternion.identity);
    }
}
