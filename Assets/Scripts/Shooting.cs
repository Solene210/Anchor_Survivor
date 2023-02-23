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
        }
        //GameObject projectileUp = Instantiate(_bulletPrefab, animator.gameObject.transform.position, Quaternion.identity);
        //GameObject projectileDown = Instantiate(_bulletPrefab, animator.gameObject.transform.position, Quaternion.identity);
        //GameObject projectileRight = Instantiate(_bulletPrefab, animator.gameObject.transform.position, Quaternion.identity);
        //GameObject projectileLeft = Instantiate(_bulletPrefab, animator.gameObject.transform.position, Quaternion.identity);
        //projectileUp.GetComponent<Rigidbody2D>().velocity = Vector2.up * _shootSpeed;
        //projectileDown.GetComponent<Rigidbody2D>().velocity = Vector2.down * _shootSpeed;
        //projectileRight.GetComponent<Rigidbody2D>().velocity = Vector2.right * _shootSpeed;
        //projectileLeft.GetComponent<Rigidbody2D>().velocity = Vector2.left * _shootSpeed;
        //projectileUp.transform.parent = _bulletGroup.transform;
        //projectileDown.transform.parent = _bulletGroup.transform;
        //projectileRight.transform.parent = _bulletGroup.transform;
        //projectileLeft.transform.parent = _bulletGroup.transform;
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
