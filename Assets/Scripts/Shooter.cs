using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab, gun;
    
    private AttackerSpawner myLaneSpawner;
    private Animator animator;
    private GameObject projectileParent;

    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Awake()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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

    public void Fire()
    {
        var newProjectile = Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
