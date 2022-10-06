using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private Transform _cameraRig;

    private Rigidbody _rigidbody;

    private PlayerInput _playerInput;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        Rotate();
    }

    void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveSpeed * new Vector3(_playerInput.Xinput, 0, _playerInput.Zinput));
    }

    void Rotate()
    {
        transform.rotation = _cameraRig.rotation;
    }

}
