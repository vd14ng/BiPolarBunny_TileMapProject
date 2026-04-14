using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public TMP_Text healthText;
    
    // CHANGE HEALTH
        // UI - what our health is
        // if our health is different, UPDATE it
    void Start()
    {
        UpdateHealth();
    }
    
    // for healing or taking damage
    public void ChangeHealth(int amount)
    {
        // positive number = heal, negative number = damage
        currentHealth += amount;
        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealth();

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateHealth()
    {
        // printing out the HP in the UI
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }
    
}
