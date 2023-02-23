using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _spawnInterval;
    [SerializeField]
    private float _spawnerRadius;
    [SerializeField]
    private Color _color;
    [SerializeField]
    private bool _drawGizmo;

    void Start()
    {
        StartCoroutine(SpawnEnemy(_spawnInterval, _enemyPrefab));
    }

    private void OnDrawGizmos()
    {
        if (_drawGizmo)
        {
            Gizmos.color = _color;
            Gizmos.DrawWireSphere(transform.position, _spawnerRadius);
        }
    }
    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        interval= Mathf.Max(_spawnInterval - Time.timeSinceLevelLoad * 0.05f, 0.1f);
        yield return new WaitForSeconds(interval);
        Vector2 position = Random.insideUnitCircle * _spawnerRadius + (Vector2)transform.position;
        GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }
}
