using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab, gun;
    
    private AttackerSpawner myLaneSpawner;
    private Animator animator;

    private void Awake()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update() => animator.SetBool("isAttacking", IsAttackerInLine());

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

    private bool IsAttackerInLine() => !(myLaneSpawner.transform.childCount <= 0);

    public void Fire() => Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity);
}
