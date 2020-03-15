using UnityEngine;

public class Attacker : MonoBehaviour
{  
    private float currentSpeed = 1f;
    private GameObject currentTarget;
    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void Update() => transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

    public void SetMovementSpeed(float speed) => currentSpeed = speed;

    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }
}
