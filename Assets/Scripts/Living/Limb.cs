using UnityEngine;
using UnityEngine.Events;

public class Limb : MonoBehaviour, IHitDetector {
    public float damageMultiplier = 1f;
    public UnityEvent<float> LimbHit = new();

    public void OnHit(float damage) {
        Debug.Log($"{name} hit!");
        LimbHit.Invoke(damage * damageMultiplier);
    }
}