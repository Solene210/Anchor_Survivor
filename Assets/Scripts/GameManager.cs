using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killEnemy;

    private void Awake()
    {
        _killEnemy.m_value = 0;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitte le jeu");
    }
}
