using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(Animator))]

public class Mob : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _deathHeigth = -1f;

    private Rigidbody _rigidbody;
    private Animator _animator;

    public event Action<Mob> Fall;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float speed = MoveForward();

        _animator.SetFloat("Speed", speed);

        if (transform.position.y <= _deathHeigth)
        {
            Fall?.Invoke(this);
        }
    }

    private float MoveForward()
    {
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = transform.forward.x * _speed;
        velocity.z = transform.forward.z * _speed;

        _rigidbody.velocity = velocity;

        float speed = velocity.magnitude;
        return speed;
    }
}