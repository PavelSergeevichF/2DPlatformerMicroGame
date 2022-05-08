using UnityEngine;
using UnityEditor.Animations;

public class SimpleEnemyAi : MonoBehaviour
{
    private State _currentState;
    private IdleState _idleState;
    private ChaseState _chaseState;
    private AttackState _attackState;
    public Vector3Variable TargetPosition;

    [SerializeField]
    private IntEventChannel _dealDamage;
    [SerializeField]
    private float _attackRange = 1;
    [SerializeField]
    private float _agroRange = 2;
    [SerializeField]
    private int _damag=3;
    private void Start()
    {
        _attackState = new AttackState(_damag, _dealDamage);
        _chaseState = new ChaseState(_attackState, null, TargetPosition, transform, _attackRange, _agroRange);
        _idleState = new IdleState(_chaseState, TargetPosition, transform, _attackRange);
        _chaseState.IdleState = _idleState;
        _currentState = _idleState;
    }
    private void Update()
    {
        RunStateMachine();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _agroRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
    private void RunStateMachine()
    {
        State nextState = _currentState?.RunCurrentState();
        if(nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }
    private void SwitchToTheNextState(State nextState)
    {
        _currentState = nextState;
    }

    public static bool IsInRange(Vector3 myPos, Vector3 targetPos, float distance)
    {
        float distanceToTarget = (myPos - targetPos).magnitude;
        if(distanceToTarget<distance)
        {
            return true;
        }
        return false;
    }
    public static bool IsOutOfRange(Vector3 myPos, Vector3 targetPos, float distance)
    {
        float distanceToTarget = (myPos - targetPos).magnitude;
        if (distanceToTarget < distance)
        {
            return true;
        }
        return false;
    }
}

public class IdleState : State
{
    public ChaseState ChaseState;
    public Vector3Variable TargetPosition;
    public Transform MyTransform;
    [SerializeField]
    private float _attackRange;

    public IdleState(ChaseState chaseState, Vector3Variable isInAttackRange, Transform myTransform, float attackRange)
    {
        ChaseState = chaseState;
        this.TargetPosition = isInAttackRange;
        MyTransform = myTransform;
        _attackRange = attackRange;
    }
    public override State RunCurrentState()
    {
        if (SimpleEnemyAi.IsInRange(MyTransform.position, TargetPosition.Vector3, _attackRange))
        {

            return ChaseState;
        }
        return this;
    }
}

public class ChaseState : State
{
    public AttackState AttackState;
    public IdleState IdleState;
    public Vector3Variable TargetPosition;
    public Transform MyTransform;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _agroRange;
    [SerializeField]
    private float MoveSpeed = 0.4f;
    public ChaseState(AttackState attackState, IdleState idleState, Vector3Variable TargetPosition, Transform myTransform, float attackRange, float agroRange)
    {
        AttackState = attackState;
        IdleState = idleState;
        this.TargetPosition = TargetPosition;
        MyTransform = myTransform;
        _attackRange = attackRange;
        _agroRange = agroRange;
    }
    public override State RunCurrentState()
    {
        if(SimpleEnemyAi.IsInRange(MyTransform.position, TargetPosition.Vector3, _agroRange))
        {
            MoveTowards(TargetPosition.Vector3, MyTransform);
            return IdleState;
        }
        if (SimpleEnemyAi.IsInRange(MyTransform.position, TargetPosition.Vector3, _attackRange))
        {
            return AttackState;
        }
        
        return this;
    }
    private void MoveTowards(Vector3 vector3, Transform myTransform)
    {
        MyTransform.position += (vector3 - MyTransform.position).normalized* MoveSpeed * Time.deltaTime;
    }
}

public class AttackState : State
{
    public int Damag;
    private IntEventChannel _dealDamage;

    public AttackState(int _damag, IntEventChannel _dealDamage)
    {
        Damag = _damag;
        this._dealDamage = _dealDamage;
    }
    public override State RunCurrentState()
    {
        _dealDamage.RaiseEvent(Damag);
        Debug.Log("deal damage ="+ Damag);
        return this;
    }
}

public abstract class State
{
    public abstract State RunCurrentState();
}