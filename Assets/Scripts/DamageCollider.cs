using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    // Takes lives when an attacker reaches left side of the screen and destroys itself
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Lives>().TakeLife();
        Destroy(collision.gameObject);
    }
}
