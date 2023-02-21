using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _moveTarget = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, (Time.deltaTime * _speed));
    }

    private Transform _moveTarget;   
}
