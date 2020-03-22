using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    public void AttackerSpawned() => numberOfAttackers++;

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            Debug.Log("End level Now!");
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawners)
        {
            spawner.StopSpawing();
        }
    }
}
