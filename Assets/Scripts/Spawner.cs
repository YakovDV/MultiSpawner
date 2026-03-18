using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Mob _prefab;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Target _target;

    public void SpawnMob()
    {
        Mob mob = Instantiate(_prefab, transform.position, Quaternion.identity);

        mob.SetTarget(_target);

        mob.Death += DestroyMob;
    }

    private void DestroyMob(Mob mob)
    {
        mob.Death -= DestroyMob;

        _explosion.ShowEffect(mob.transform.position);

        Destroy(mob.gameObject);
    }
}