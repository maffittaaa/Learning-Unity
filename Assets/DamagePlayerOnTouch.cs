using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lazy Singleton(check it out!!!!)

public class DamagePlayerOnTouch : MonoBehaviour
{
    [SerializeField] private float DamageToDeal = 1;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            HealthComponent healthComponent = collider.GetComponent<HealthComponent>();
            if (healthComponent)
            {
                healthComponent.DealDamage(DamageToDeal);
            }
        }
    }
    //    //DontDestroyOnLoad(gameObject); //do not destroy this when transitioning between scenes

}