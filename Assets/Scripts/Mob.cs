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
    private Target _target;

    public event Action<Mob> Death;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        _animator.SetFloat("Speed", _speed);
    }

    private void FixedUpdate()
    {
        SetDirection();
        MoveForward();

        if (transform.position.y <= _deathHeigth)
        {
            Death?.Invoke(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>() != null)
        {
            Death?.Invoke(this);
        }
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }

    private void SetDirection()
    {
        _direction = (_target.transform.position - transform.position).normalized;

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