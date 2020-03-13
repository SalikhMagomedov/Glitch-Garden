using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab, gun;
    
    private AttackerSpawner myLaneSpawner;

    private void Awake() => SetLaneSpawner();

    private void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("shoot pew pew");
        }
        else
        {
            Debug.Log("sit and wait");
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawners)
        {
            bool IsCloseEnoigh = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;

            if (IsCloseEnoigh)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane() => !(myLaneSpawner.transform.childCount <= 0);

    public void Fire() => Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity);
}
