using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab, gun;

    public void Fire(float damage) => Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity);
}
