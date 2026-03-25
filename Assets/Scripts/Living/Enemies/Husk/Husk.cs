using System;
using UnityEngine;
public class Husk : IEnemyStateManager {
    private IEnemyState[] states;
    [InspectorName("First state")]
    [SerializeField] private IEnemyState currentState = null;
    [InspectorName("Body damage colliders")]
    [SerializeField] private Collider[] damageColliders = new Collider[] {};

    void Awake() {
        states = GetComponents<IEnemyState>();
    }

    void Start() {
        if (currentState == null) {
            Debug.LogWarning($"First state is not set, setting default: {states[0].stateName}");
            currentState = states[0];
        }

        // foreach (IEnemyState state in states) {
        //     state.EnterState();
        // }
        
        currentState.EnterState();
    }

    public void Die() {
        Destroy(gameObject);
        // foreach (Collider col in damageColliders) {
        //     col.enabled = false;
        // }
    }

    public override void ChangeState(string stateName) {
        foreach (IEnemyState state in states) {
            if (!state.stateName.Equals(stateName)) continue;
            Debug.Log($"Husk changes state from: '{currentState.stateName}' to '{state.stateName}'");
            currentState.ExitState();
            currentState = state;
            currentState.EnterState();
            return;
        }
        
        Debug.LogError($"State with name {stateName} does not exist");
    }
}

public static class HuskStates {
    public static readonly string HuskLayingState = "HuskLayingState";
    public static readonly string HuskStandUpState = "HuskStandUpState";
    public static readonly string HuskStandingState = "HuskStandingState";
}
