using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeAIMovement : AIMovement
{
    public enum EEmployeeState
    {
        PICK,
        DELIVER,
        DETECT,
        MAX
    }

    private EEmployeeState _currentState;
    private EEmployeeState _previousState;
    [SerializeField]
    private Transform _goalPosition;
    private new void Awake()
    {
        base.Awake();
        _currentState = EEmployeeState.PICK;
    }

    protected override void SetTarget()
    {
        StopAllCoroutines();
        switch(_currentState)
        {
            case EEmployeeState.PICK:
                StartCoroutine(CheckTarget());
                StartTrack();
                break;
            case EEmployeeState.DELIVER:
                _targetPosition = _goalPosition;
                StartTrack();
                break;
            case EEmployeeState.DETECT:
                StartCoroutine(Stun());
                break;
        }
    }

    protected override IEnumerator CheckTarget()
    {
        while (true)
        {
            //_nextItem = _interaction.GetNextItem();
            _targetPosition = _nextItem.transform;
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator Stun()
    {
        yield return new WaitForSeconds(2);
        ChangeState(_previousState);
    }

    public void ChangeState(EEmployeeState nextState)
    {
        _agent.isStopped = true;
        switch(nextState)
        {
            case EEmployeeState.PICK:
            case EEmployeeState.DELIVER:
                _currentState = nextState;
                break;
            case EEmployeeState.DETECT:
                _previousState = _currentState;
                _currentState = nextState;
                break;
        }
        SetTarget();
    }
}
