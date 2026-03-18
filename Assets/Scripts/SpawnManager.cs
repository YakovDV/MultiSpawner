using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] float _delay = 2.0f;

    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _spawners = FindObjectsOfType<Spawner>();
    }

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
        while (true)
        {
            if (_spawners.Length > 0)
            {
                int randomIndex = Random.Range(0, _spawners.Length);
                _spawners[randomIndex].SpawnMob();
            }

            yield return new WaitForSecondsRealtime(_delay);
        }
    }
}
