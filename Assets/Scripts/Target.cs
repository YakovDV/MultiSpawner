using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Vector3 _movementDirection;
    [SerializeField] private float _positionLimitX;
    [SerializeField] private float _positionLimitY;
    [SerializeField] private float _positionLimitZ;

    private void FixedUpdate()
    {
        if (transform.position.x > _positionLimitX || transform.position.x < _positionLimitX * -1)
            _movementDirection.x *= -1;
        if (transform.position.y > _positionLimitY || transform.position.y < _positionLimitY * -1)
            _movementDirection.y *= -1;
        if (transform.position.z > _positionLimitZ || transform.position.z < _positionLimitZ * -1)
            _movementDirection.z *= -1;

        transform.Translate(_movementDirection, Space.Self);
    }
}
