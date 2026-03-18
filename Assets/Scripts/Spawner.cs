using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Mob _prefab;
    [SerializeField] private Explosion _explosion;

    public void SpawnMob()
    {
        Mob mob = Instantiate(_prefab, transform.position, Quaternion.identity);

        Vector3 direction = Random.insideUnitSphere;
        direction.y = 0f;

        mob.SetDirection(direction);

        mob.Fall += DestroyMob;
    }

    private void DestroyMob(Mob mob)
    {
        mob.Fall -= DestroyMob;

        _explosion.ShowEffect(mob.transform.position);

        Destroy(mob.gameObject);
    }
}