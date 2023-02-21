using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    private EnemyBehaviour _enemyBehaviour;
    [SerializeField]
    private int _kill;
    [SerializeField]
    private IntVariable _killEnemy;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (_isDead == true)
        {
            StartCoroutine(coroutine());
            _enemyBehaviour.enabled= false;
            _rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Enemy -1");
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
        _killEnemy.m_value += _kill;
        Destroy(gameObject);;
    }

    private bool _isDead = false;
    private Rigidbody2D _rb2d;
}
