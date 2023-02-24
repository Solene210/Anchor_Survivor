using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class RewardsEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _rewardsUI;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private GameObject _bulletGroup;

    [Header("Event")]
    public UnityEvent AfterAttack;
    public UnityEvent AfterEnemyDeath;

    public void AddAttack()
    {
        AfterAttack.AddListener(DoubleAttack);
        Time.timeScale= 1.0f;
        _rewardsUI.SetActive(false);
    }

    public void AddBulletAfterEnemyDeath()
    {
        AfterEnemyDeath.AddListener(CreateBonusBullet);
        Time.timeScale= 1.0f;
        _rewardsUI.SetActive(false);
    }

    public void CreateBonusBullet()
    {
        IsEnemyDead = true;
        Debug.Log("Enemy mort devient bullet");
    }

    public void DoubleAttack()
    {
        int random = Random.Range(1, 3);
        Debug.Log("random = " + random);
        if (random == 2)
        {
            List<Vector3> projectilePositions = new List<Vector3>()
            {
                new Vector3(_playerTransform.position.x + 1, _playerTransform.position.y + 1, _playerTransform.position.z),
                new Vector3(_playerTransform.position.x - 1, _playerTransform.position.y - 1, _playerTransform.position.z),
                new Vector3(_playerTransform.position.x + 1, _playerTransform.position.y -1, _playerTransform.position.z),
                new Vector3(_playerTransform.position.x - 1, _playerTransform.position.y + 1, _playerTransform.position.z)
            };
            foreach (Vector3 position in projectilePositions)
            {
                GameObject projectile = Instantiate(_bulletPrefab, position, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = (position - _playerTransform.position).normalized * _bulletSpeed;
                projectile.transform.parent = _bulletGroup.transform;
                Destroy(projectile, 5);
            }
            Debug.Log("Double attaque");
        }
    }

    private bool _isEnemyDead;

    public bool IsEnemyDead { get => _isEnemyDead; set => _isEnemyDead = value; }
}
