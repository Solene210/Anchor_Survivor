using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;

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

    void Start()
    {
       _target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        
    }

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
        }
        Debug.Log("Double attaque");
    }

    private Transform _target;
    private bool _isEnemyDead;

    public bool IsEnemyDead { get => _isEnemyDead; set => _isEnemyDead = value; }
}
