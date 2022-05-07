using UnityEngine;
using UnityEditor.Animations;

public class SimpleEnemyAi : MonoBehaviour
{
    private State _currentState;
    private IdleState _idleState;
    private ChaseState _chaseState;
    private AttackState _attackState;
    public Transform Target;
    private void Start()
    {
        _attackState = new AttackState();
        _chaseState = new ChaseState(_attackState,false);
        _idleState = new IdleState(_chaseState, false);
        _currentState = _idleState;
    }
    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = _currentState?.RunCurrentState();
        if(nextState != null)
        {
            nextState.RunCurrentState();
        }
    }
    private void SwitchToTheNextState(State nextState)
    { }
    public bool IsInRange(Vector3 myPos, Vector3 targetPos, float distance)
    {
        float distanceToTarget = (myPos - targetPos).magnitude;
        if(distanceToTarget<distance)
        {
            return true;
        }
        return false;
    }
}
public class IdleState : State
{
    public ChaseState ChaseState;
    public bool CanSeePlayer;

    public IdleState(ChaseState chaseState, bool canSeePlayer)
    {
        ChaseState = chaseState;
        CanSeePlayer = canSeePlayer;
    }
    public override State RunCurrentState()
    { 
        if(CanSeePlayer)
        {
            return ChaseState;
        }
        return this;
    }
}

public class ChaseState : State
{
    public AttackState AttackState;
    public bool IsInAttackRange;
    public ChaseState(AttackState attackState, bool isInAttackRange)
    {
        AttackState = attackState;
        IsInAttackRange = isInAttackRange;
    }
    public override State RunCurrentState()
    {
        if(IsInAttackRange)
        {
            return AttackState;
        }
        return this;
    }
}

public class AttackState : State
{
    public AttackState()
    { }
    public override State RunCurrentState()
    {
        Debug.Log("deal damage");
        return this;
    }
}

public abstract class State
{
    public abstract State RunCurrentState();
}
//SimpleSpeedToText