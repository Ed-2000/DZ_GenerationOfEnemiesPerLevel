using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnFrequency = 2;
    [SerializeField] private float _spawnStartTime = 0;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _spawnStartTime, _spawnFrequency);
    }

    private void Spawn()
    {
        Vector3 spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
        Enemy enemy = Instantiate(_enemy, spawnPoint, Quaternion.identity);

        enemy.GetComponent<EnemyMovement>().MoveStarter(SetRandomDirection());
    }

    private Vector3 SetRandomDirection()
    {
        float directionLimit = 1f;
        Vector3 directon = new Vector3();

        directon.x = Random.Range(-directionLimit, directionLimit);
        directon.z = Random.Range(-directionLimit, directionLimit);

        return directon;
    }
}