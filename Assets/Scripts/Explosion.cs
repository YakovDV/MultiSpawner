using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _effectDestroyDelay = 5f;

    public void ShowEffect(Vector3 position)
    {
        GameObject deathEffect = Instantiate(_explosion, position, Quaternion.identity);

        Destroy(deathEffect.gameObject, _effectDestroyDelay);
    }
}