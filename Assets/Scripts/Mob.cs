using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(Animator))]

public class Mob : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _deathHeigth = -1f;

    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private Animator _animator;

    public event Action<Mob> Fall;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        _animator.SetFloat("Speed", _speed);
    }

    private void FixedUpdate()
    {
        MoveForward();

        if (transform.position.y <= _deathHeigth)
        {
            Fall?.Invoke(this);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;

        SetRotation();
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.LookRotation(_direction);
    }

    private void MoveForward()
    {
        Vector3 velocity = _direction * _speed;
        velocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = velocity;
    }
}