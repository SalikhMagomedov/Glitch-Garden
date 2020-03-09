using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update() => transform.Translate(Vector2.right * speed * Time.deltaTime);
}
