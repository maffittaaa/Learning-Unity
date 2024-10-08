using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private HealthComponent PlayerHealth;

    // Start is called before the first frame update
    private void Start()
    {
        PlayerHealth = FindAnyObjectByType<HealthComponent>();
        if(PlayerHealth)
        {
            PlayerHealth.OnPlayerDiedEvent.AddListener(OnPlayerDied); //whenever the event happens, the addlistener will know
        }
    }
    private void OnPlayerDied()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
