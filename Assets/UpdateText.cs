using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    [SerializeField] private IntVariable _MoneyCollected;
    private TextMeshProUGUI _label;

    private void Awake()
    {
        _label = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
       
    }

    void Update()
    {
        _label.text = _MoneyCollected.m_value.ToString();
    }
}