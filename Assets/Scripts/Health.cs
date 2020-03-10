using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject deathVfx;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVfx) { return; }

        var deathVfxObject = Instantiate(deathVfx, transform.position, Quaternion.identity);
        Destroy(deathVfxObject, 1f);
    }
}
