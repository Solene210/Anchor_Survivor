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

    [Header("Event")]
    public UnityEvent AfterAttack;
    public UnityEvent AfterEnemyDeath;

    void Start()
    {
        _target = GameObject.Find("Player").transform;
        AfterAttack.AddListener(DoubleAttack);
        AfterEnemyDeath.AddListener(CreateBonusBullet);
    }

    void Update()
    {
        
    }

    public void AddAttack()
    {
        //AfterAttack.AddListener(DoubleAttack);
        Time.timeScale= 1.0f;
        _rewardsUI.SetActive(false);
        AfterAttack.Invoke();
    }

    public void AddBullerAfterEnemyDeath()
    {
        //AfterEnemyDeath.AddListener(CreateBonusBullet);
        Time.timeScale= 1.0f;
        _rewardsUI.SetActive(false);
        AfterEnemyDeath.Invoke();
    }

    private void CreateBonusBullet()
    {
        Instantiate(_bulletPrefab, _target);
        _bulletPrefab.GetComponent<Rigidbody2D>().velocity = Vector2.right * _bulletSpeed;
        Debug.Log("Enemy devient bullet");

    }

    public void DoubleAttack()
    {
        Debug.Log("Double attaque");
    }

    private Transform _target;
}
