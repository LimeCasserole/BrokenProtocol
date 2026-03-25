using UnityEngine;

public abstract class IEnemyState : MonoBehaviour {
    [HideInInspector]
    public string stateName;
    public abstract void EnterState();
    public abstract void ExitState();
}

public abstract class IEnemyStateManager : MonoBehaviour {
    public abstract void ChangeState(string stateName);
}