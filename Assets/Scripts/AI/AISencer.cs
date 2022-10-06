using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AISensor : MonoBehaviour
{
    public UnityEvent CatchPlayerStill = new UnityEvent();

    private PlayerHealth _playerHealth;
    private GameObject _player;
    private Camera _aiSight;

    private Vector3 _playerPosition;
    private Plane[] _eyePlanes;

    private bool _isFindPlayer = false;
    private float _aiColliderRadiusSize = 5f;
    private int _playerState;

    void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        
    }

    private void Start()
    {
        _aiSight = transform.GetComponentInChildren<Camera>();
        // PlayerHealth의 OnDamage 의 AddListener(SearchPlayer(gameObject.transform.position, _aiColliderRadiusSize)); 추가
    }

    void Update()
    {
        // 상태 변화를 _playerHealth에 받아오기 or 이벤트로 상황 받기
    }

    private void UpdateAIState()
    {
        if (IsFindPlayer())
        {
            // 찾으면 거기로 이동하라고 이벤트 쏘기..?
        }
        else
        {
            return;
        }
    }

    private bool IsFindPlayer()
    {
        if (/* 플레이어의 상태가 도둑질 상태가 아닐때 만 */ true)
        {
            return false;
        }

        Bounds targetBounds = _player.GetComponent<SkinnedMeshRenderer>().bounds;
        _eyePlanes = GeometryUtility.CalculateFrustumPlanes(_aiSight);
        _isFindPlayer = GeometryUtility.TestPlanesAABB(_eyePlanes, targetBounds);

        return _isFindPlayer;
    }

    /// <summary>
    /// 콜라이더에 플레이어가 닿았을 때 CatchPlayerStill 이벤트 Invoke()
    /// </summary>
    /// <param name="other">플레이어</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CatchPlayerStill.Invoke();
        }
    }

    /// <summary>
    /// 플레이어가 레고를 밟았을 때 나오는 동적 콜라이더
    /// </summary>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    private void SearchPlayer(Vector3 center, float radius)
    {
        int _maxColliders = 10;
        Collider[] hitColliders = new Collider[_maxColliders];
        int _numColliders = Physics.OverlapSphereNonAlloc(center, radius, hitColliders);
        for (int i = 0; i < _numColliders; i++)
        {
            hitColliders[i].SendMessage("Serch Player!");
        }
    }
}
