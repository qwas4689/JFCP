using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraRig;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _moveSpeed;
    private float _rotateSpeed;
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
        _rigidbody.MovePosition(new Vector3(_playerInput.Xinput * _moveSpeed, 0, _playerInput.Zinput));

    }
    void Rotate()
    {
        transform.rotation = _cameraRig.rotation;
    }


}
