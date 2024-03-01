using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] Monster monsterPrefab;
    [SerializeField] float spawnTime;
    [SerializeField] Transform[] wayPoints;

    private void OnEnable()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnRoutine);
    }

    Coroutine spawnRoutine;
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Monster monster = Instantiate(monsterPrefab, wayPoints[0].position, wayPoints[0].rotation);
            monster.SetWayPoints(wayPoints);
        }
    }
}
