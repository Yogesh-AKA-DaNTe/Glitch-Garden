using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Variables for storing speed and damage of projectiles
    [SerializeField] float speed = 10f;
    [SerializeField] float damage = 50f;

    void Update()
    {
        // Moves projectiles
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // Deals damage to the enemies and destroys the projectile
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
