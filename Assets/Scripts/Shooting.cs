using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : StateMachineBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _shootSpeed;
    [SerializeField]
    private GameObject _bulletGroup;

    private GameObject _player;

    private void Awake()
    {
        _bulletGroup = GameObject.Find("BulletGroup");
        _player = GameObject.Find("Player");
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform _playerTransform = _player.transform;
        List<Vector3> projectilePositions = new List<Vector3>()
        {
            new Vector3(_playerTransform.position.x, _playerTransform.position.y + 1, _playerTransform.position.z),
            new Vector3(_playerTransform.position.x, _playerTransform.position.y - 1, _playerTransform.position.z),
            new Vector3(_playerTransform.position.x + 1, _playerTransform.position.y, _playerTransform.position.z),
            new Vector3(_playerTransform.position.x - 1, _playerTransform.position.y, _playerTransform.position.z)
        };
        foreach (Vector3 position in projectilePositions)
        {
            GameObject projectile = Instantiate(_bulletPrefab, position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = (position - _playerTransform.position).normalized * _shootSpeed;
            projectile.transform.parent = _bulletGroup.transform;
            Destroy(projectile, 5);
        }
        _player.GetComponent<SpriteRenderer>().color = Color.green;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player.GetComponent<SpriteRenderer>().color = Color.red;
        RewardsEffects r = GameObject.Find("RewardsManager").GetComponent<RewardsEffects>();
        r.AfterAttack?.Invoke();
    }
}
