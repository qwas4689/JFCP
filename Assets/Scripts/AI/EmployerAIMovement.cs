using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployerAIMovement : AIMovement
{
    public enum EEmployerState
    {
        IDLE,
        TRACE,
        RETURN,
        MAX
    }

    private EEmployerState _currentState;
    [SerializeField]
    private Transform _playerPosition; 
    private Item _returnItem;
    private new void Awake()
    {
        base.Awake();
        _currentState = EEmployerState.IDLE;
    }

    protected override void SetTarget()
    {
        StopAllCoroutines();
        switch (_currentState)
        {
            case EEmployerState.IDLE:
                break;
            case EEmployerState.TRACE:
                // AIInteraction에서 플레이어 위치 받아오기
                StartCoroutine(CheckTarget());
                break;
            case EEmployerState.RETURN:
                // AIInteraction에서 아이템 받아오기
                _targetPosition = _returnItem.Data.OriginalPosition;
                StartTrack();
                break;
        }
    }

    protected override IEnumerator CheckTarget()
    {
        while (true)
        {
            _targetPosition = _playerPosition;
            StartTrack();
            yield return new WaitForSeconds(1);
        }
    }

    public void ChangeState(EEmployerState nextState)
    {
        _agent.isStopped = true;
        switch (nextState)
        {
            case EEmployerState.IDLE:
            case EEmployerState.TRACE:
            case EEmployerState.RETURN:
                _currentState = nextState;
                break;
        }
        SetTarget();
    }
}
