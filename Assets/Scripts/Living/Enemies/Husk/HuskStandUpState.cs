using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IEnemyStateManager))]
[RequireComponent(typeof(Animator))]
public class HuskStandUpState : IEnemyState {
    [SerializeField] private string triggerName = "StandUp";
    // TODO: hardcoding this value is a bad idea, fix in future
    [SerializeField] private float standUpTime = 2.5f;
    
    private Animator animator;
    private IEnemyStateManager enemyStateManager;
    private Coroutine standUpCoroutine = null;

    void Awake() {
        stateName = HuskStates.HuskStandUpState;
    }
    void Start() {
        animator = GetComponent<Animator>();
        enemyStateManager = GetComponent<IEnemyStateManager>();
    }
    
    public override void EnterState() {
        enabled = true;
        
        animator.SetTrigger(triggerName);
        if (standUpCoroutine != null) {
            StopCoroutine(standUpCoroutine);
            standUpCoroutine = null;
        }
        StartCoroutine(wait(standUpTime));
    }

    public override void ExitState() {
        enabled = false;
        if (standUpCoroutine != null) {
            StopCoroutine(standUpCoroutine);
            standUpCoroutine = null;
        }
    }
    private IEnumerator wait(float time) {
        yield return new WaitForSeconds(time);
        standUpCoroutine = null;
        enemyStateManager.ChangeState(HuskStates.HuskStandingState);
    }
}