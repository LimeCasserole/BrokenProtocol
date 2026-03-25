using UnityEngine;
using UnityEngine.Events;

public class BasicHealth : MonoBehaviour {
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public UnityEvent OnDeath = new UnityEvent();

    public void DealDamage(float damage) {
        if (currentHealth <= 0) return;
        
        currentHealth -= damage;
        if (currentHealth <= 0) {
            OnDeath.Invoke();
        }
    }
}