using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab, gun;

    public void Fire() => Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity);
}
