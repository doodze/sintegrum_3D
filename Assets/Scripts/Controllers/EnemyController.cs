using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemyCount;
    [SerializeField] private List<Enemy> _enemyList;
    [SerializeField] private float _startPoint;
    [SerializeField] private float _spawnStep;

    private ObjectPool<Enemy> _enemyPool;

    private void Awake()
    {
        GameController.Instance.SetEnemyController(this);
        GameController.Instance.GameStarted += OnGameStarted;        

        _enemyPool = new ObjectPool<Enemy>(CreateEnemy, OnGetEnemy, OnReleaseEnemy, collectionCheck: true);        
    }

    private Enemy CreateEnemy()
    {
        return Instantiate(_enemyPrefab);
    }

    private void OnGetEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.GotHit += OnGotHit;
        _enemyList.Add(enemy);
    }

    private void OnReleaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.GotHit -= OnGotHit;        
        _enemyList.Remove(enemy);
    }

    private void OnGotHit(Enemy enemy)
    {
        _enemyPool.Release(enemy);
    }

    private void OnGameStarted()
    {
        float startPoint = _startPoint;

        for (int i = 0; i < _enemyCount; i++)
        {
            var enemy = _enemyPool.Get();
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, startPoint);
            startPoint += _spawnStep;
        }
    }
}
