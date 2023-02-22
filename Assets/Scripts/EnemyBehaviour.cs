using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Start()
    {
        _moveTarget = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, (Time.deltaTime * _speed));
    }

    private Transform _moveTarget;   
}
