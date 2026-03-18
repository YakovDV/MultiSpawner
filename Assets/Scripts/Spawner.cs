using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Mob _prefab;
    [SerializeField] private Explosion _explosion;

    public void SpawnMob()
    {
        Quaternion rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

        Mob mob = Instantiate(_prefab, transform.position, rotation);

        mob.Fall += DestroyMob;
    }

    private void DestroyMob(Mob mob)
    {
        mob.Fall -= DestroyMob;

        _explosion.ShowEffect(mob.transform.position);

        Destroy(mob.gameObject);
    }
}