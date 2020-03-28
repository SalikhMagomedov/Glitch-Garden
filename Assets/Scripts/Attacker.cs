using UnityEngine;

public class Attacker : MonoBehaviour
{  
    private float currentSpeed = 1f;
    private GameObject currentTarget;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();

        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed) => currentSpeed = speed;

    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }

        var health = currentTarget.GetComponent<Health>();

        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
