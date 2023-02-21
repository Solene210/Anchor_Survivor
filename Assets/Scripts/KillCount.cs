using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killEnemy;

    private void Awake()
    {
        _killCounterText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _killCounterText.text = _killEnemy.m_value.ToString();
    }
    private TextMeshProUGUI _killCounterText;
}