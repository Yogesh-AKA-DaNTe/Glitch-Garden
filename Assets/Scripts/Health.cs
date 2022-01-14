using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Variables for storing Health and Death VFX
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    // Function to decrease the health by the amount of damage taken
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    // Function to instantiate the Death VFX
    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
        Destroy(deathVFXObject, 1f);
    }
}
