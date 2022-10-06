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
        // PlayerHealth�� OnDamage �� AddListener(SearchPlayer(gameObject.transform.position, _aiColliderRadiusSize)); �߰�
    }

    void Update()
    {
        // ���� ��ȭ�� _playerHealth�� �޾ƿ��� or �̺�Ʈ�� ��Ȳ �ޱ�
    }

    private void UpdateAIState()
    {
        if (IsFindPlayer())
        {
            // ã���� �ű�� �̵��϶�� �̺�Ʈ ���..?
        }
        else
        {
            return;
        }
    }

    private bool IsFindPlayer()
    {
        if (/* �÷��̾��� ���°� ������ ���°� �ƴҶ� �� */ true)
        {
            return false;
        }

        Bounds targetBounds = _player.GetComponent<SkinnedMeshRenderer>().bounds;
        _eyePlanes = GeometryUtility.CalculateFrustumPlanes(_aiSight);
        _isFindPlayer = GeometryUtility.TestPlanesAABB(_eyePlanes, targetBounds);

        return _isFindPlayer;
    }

    /// <summary>
    /// �ݶ��̴��� �÷��̾ ����� �� CatchPlayerStill �̺�Ʈ Invoke()
    /// </summary>
    /// <param name="other">�÷��̾�</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CatchPlayerStill.Invoke();
        }
    }

    /// <summary>
    /// �÷��̾ ���� ����� �� ������ ���� �ݶ��̴�
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
