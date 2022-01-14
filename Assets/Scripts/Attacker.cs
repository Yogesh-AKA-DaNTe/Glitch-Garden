using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // Variables for speed and target of attackers
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        // Initial setup
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    // Function for handling the destruction of attackers
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    // Function for setting the attack bool and target for the attackers
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    // Function for giving a strike to a defender and dealing damage
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    void Update()
    {
        // Moving the attackers
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    // Function for updating the animation state
    public void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    // Function for setting the movement speed
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
}
