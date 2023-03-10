using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavour : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
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

    private Rigidbody2D _rb2D;
    private Vector2 _direction;
}
