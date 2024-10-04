using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable] //should be saved on the disk
public class OnPlayerHealthChanged : UnityEvent<float> {} //declaration of an event with parameters

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 12.0f;
    private float currentHealth = 0.0f;
    private float normalizedHealth = 0.0f;

    public OnPlayerHealthChanged OnPlayerHealthChangedEvent;

    private void Start()
    {
        currentHealth = MaxHealth;
        normalizedHealth = currentHealth / MaxHealth;

        OnPlayerHealthChangedEvent.Invoke(normalizedHealth);
    }

    public void DealDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        normalizedHealth = currentHealth / MaxHealth;

        OnPlayerHealthChangedEvent.Invoke(normalizedHealth);

        if (normalizedHealth <= 0.0f)
        {
            RestartGame();
        }

    }

    public void HealDamage(float healthAmount)
    {
        currentHealth += healthAmount;
        normalizedHealth = currentHealth / MaxHealth;

        OnPlayerHealthChangedEvent.Invoke(normalizedHealth);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
