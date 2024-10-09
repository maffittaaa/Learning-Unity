using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenHealthToPlayer : MonoBehaviour
{
    [SerializeField] private float HealthToRegen = 1.0f;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            HealthComponent healthComponent = collider.GetComponent<HealthComponent>();
            if (healthComponent && healthComponent.CanHealAmount(HealthToRegen))
            {
                healthComponent.HealDamage(HealthToRegen);
            }
        }
    }
}
