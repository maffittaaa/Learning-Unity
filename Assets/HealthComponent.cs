using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable] //should be saving data on the disk
public class OnPlayerHealthChanged : UnityEvent<float> {} //declaration of an event with parameters

[System.Serializable]
public class OnPlayerDied : UnityEvent {}

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 12.0f;
    private float currentHealth = 0.0f;
    private float normalizedHealth = 0.0f;

    public OnPlayerHealthChanged OnPlayerHealthChangedEvent;
    public OnPlayerDied OnPlayerDiedEvent;

    private void Start()
    {
        currentHealth = MaxHealth;
        normalizedHealth = currentHealth / MaxHealth;

        OnPlayerHealthChangedEvent.Invoke(normalizedHealth);
    }

    public void DealDamage(float damageAmount)
    {
        ModifyHealth(-damageAmount);
        normalizedHealth = currentHealth / MaxHealth;

        OnPlayerHealthChangedEvent.Invoke(normalizedHealth);

        if (normalizedHealth <= 0.0f) 
        {
            OnPlayerDiedEvent.Invoke();
        }
    }

    public void HealDamage(float healthAmount)
    {

        ModifyHealth(healthAmount);
        OnPlayerHealthChangedEvent.Invoke(normalizedHealth);
    }

    private void ModifyHealth(float modifier)
    {
        currentHealth = Mathf.Clamp(currentHealth + modifier, 0.0f, MaxHealth); 
        normalizedHealth = currentHealth / MaxHealth;
    }

    public bool CanHealAmount(float amount)
    {
        return normalizedHealth < 1.0f;
    }
}
