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
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private Transform _playerTransform;

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

    public void AddBullerAfterEnemyDeath()
    {
        AfterEnemyDeath.AddListener(CreateBonusBullet);
        Time.timeScale= 1.0f;
        _rewardsUI.SetActive(false);
    }

    private void CreateBonusBullet()
    {
        Instantiate(_bulletPrefab, _target);
        _bulletPrefab.GetComponent<Rigidbody2D>().velocity = Vector2.right * _bulletSpeed;
        Debug.Log("Enemy devient bullet");
    }

    public void DoubleAttack()
    {
        //GameObject projectileUp = Instantiate(_bulletPrefab, _playerTransform.position, Quaternion.identity);
        //GameObject projectileDown = Instantiate(_bulletPrefab, _playerTransform.position, Quaternion.identity);
        //GameObject projectileRight = Instantiate(_bulletPrefab, _playerTransform.position, Quaternion.identity);
        //GameObject projectileLeft = Instantiate(_bulletPrefab, _playerTransform.position, Quaternion.identity);

        //projectileUp.GetComponent<Rigidbody2D>().velocity = Vector2.up * _bulletSpeed;
        //projectileDown.GetComponent<Rigidbody2D>().velocity = Vector2.down * _bulletSpeed;
        //projectileRight.GetComponent<Rigidbody2D>().velocity = Vector2.right * _bulletSpeed;
        //projectileLeft.GetComponent<Rigidbody2D>().velocity = Vector2.left * _bulletSpeed;

        Debug.Log("Double attaque");
    }

    private Transform _target;
}
