using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 50f;

    private void Update() => transform.Translate(Vector2.right * speed * Time.deltaTime);

    private void OnTriggerEnter2D(Collider2D collision) => collision.GetComponent<Health>().DealDamage(damage);
}
