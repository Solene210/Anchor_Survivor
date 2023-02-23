using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    private EnemyBehaviour _enemyBehaviour;
    [SerializeField]
    private IntVariable _killEnemy;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _spawnerRadius;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isDead == true)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(coroutine());
            _enemyBehaviour.enabled= false;
            _isDead = false;
            _rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Collision enemy avec bullet");
            _isDead = true;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(0);
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(0.10f);
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.10f);
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        _killEnemy.m_value += 1;
        RewardsEffects r = GameObject.Find("RewardsManager").GetComponent<RewardsEffects>();
        r.AfterEnemyDeath?.Invoke();
        if(r.IsEnemyDead == true)
        {
            Vector2 position = Random.insideUnitCircle * _spawnerRadius + (Vector2)transform.position;
            GameObject projectile = Instantiate(_bulletPrefab, position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = position.normalized * _bulletSpeed;
            Destroy(projectile, 5);
        }
        Destroy(gameObject);
    }

    private bool _isDead = false;
    private Rigidbody2D _rb2d;
}
