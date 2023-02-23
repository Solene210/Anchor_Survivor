using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killEnemy;
    [SerializeField]
    private GameObject _rewardUI;
    [SerializeField]
    private int _kills;

    private void Awake()
    {
        _killCounterText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _killCounterText.text = _killEnemy.m_value.ToString();
        if (_killEnemy.m_value >= _kills)
        {
            _rewardUI.SetActive(true);
            Time.timeScale = 0;
            _killEnemy.m_value = 0;
            _kills *= 2;
        }
    }
    private TextMeshProUGUI _killCounterText;
}