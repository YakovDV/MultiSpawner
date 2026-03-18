using System.Collections;
using UnityEngine;

public class MultiSpawner : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private float _delay = 2.0f;

    private Coroutine _spawnCoroutine;

    private void OnEnable()
    {
        _spawnCoroutine = StartCoroutine(SpawnDelayed());
    }

    private void OnDisable()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnDelayed()
    {
        WaitForSecondsRealtime delay = new (_delay);

        while (true)
        {
            if (_spawners.Length > 0)
            {
                int randomIndex = Random.Range(0, _spawners.Length);
                _spawners[randomIndex].SpawnMob();
            }

            yield return delay;
        }
    }
}
