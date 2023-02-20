using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerBehavour : MonoBehaviour
{
    [Header("Movement parameter")]
    [SerializeField]
    private float _speed;

    [Header("Shoot parameter")]
    [SerializeField] 
    private float _shootSpeed;
    [SerializeField]
    private float _nextShootTime;
    [SerializeField]
    private float _shootDelay;
    [SerializeField]
    private float _shootDrag;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Rigidbody2D _bulletRb2D;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
        Shoot(Vector2.up);
        Shoot(Vector2.down);
        Shoot(Vector2.left);
        Shoot(Vector2.right);
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = _direction.normalized * _speed * Time.fixedDeltaTime;
    }

    private void Movement()
    {
        _direction.x = Input.GetAxisRaw("Horizontal") * _speed;
        _direction.y = Input.GetAxisRaw("Vertical") * _speed;
    }

    private void Shoot(Vector2 direction)
    {
        if (Time.timeSinceLevelLoad > _nextShootTime)
        {
            GameObject projectile = Instantiate(_bullet, direction, Quaternion.identity);

            projectile.GetComponent<Rigidbody2D>().velocity = direction * _shootSpeed;
            //_nextShootTime = Time.timeSinceLevelLoad + _shootDelay;
        }
    }

    private Rigidbody2D _rb2D;
    private Vector2 _direction;
}