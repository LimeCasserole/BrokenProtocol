using UnityEngine;

[RequireComponent(typeof(IEnemyStateManager))]
public class HuskLayingState : IEnemyState {
    private IEnemyStateManager enemyStateManager;
    private Coroutine standUpCoroutine = null;

    void Awake() {
        stateName = HuskStates.HuskLayingState;
    }
    void Start() {
        enemyStateManager = GetComponent<IEnemyStateManager>();
    }
    
    // Connected via ColliderWrapper
    public void StandUp() {
        enemyStateManager.ChangeState(HuskStates.HuskStandUpState);
    }
    public override void EnterState() {
        enabled = true;
    }

    public override void ExitState() {
        enabled = true;
    }
}