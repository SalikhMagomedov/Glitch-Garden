using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private Attacker attacker;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;

    private bool spawn = true;

    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawn();
        }
    }

    private void Spawn()
    {
        var newAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }
}
