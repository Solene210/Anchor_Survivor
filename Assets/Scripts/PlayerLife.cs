using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOver;

    private void Start()
    {
        Time.timeScale= 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");

            _isDead = true;
        }
    }
    private void Update()
    {
        if (_isDead == true)
        {
            Time.timeScale = 0f;

            _gameOver.SetActive(true);
        }

    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private bool _isDead = false;
}
