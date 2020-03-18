using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private Attacker[] attackers;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;

    private bool spawn = true;

    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker() => Spawn(attackers[Random.Range(0, attackers.Length)]);

    private void Spawn(Attacker attacker)
    {
        var newAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }
}
