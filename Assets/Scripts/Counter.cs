using TMPro;
using UnityEngine;
using System;
public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private CounterView _counterView;

    private bool _isCounterRunning = false;

    private void OnEnable()
    {
        _counterView.CounterChanged += UpdateCounterText;
    }

    private void OnDisable()
    {
        _counterView.CounterChanged -= UpdateCounterText;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounterRunning)
            {
                _counterView.StopCounter();
                _isCounterRunning = false;
            }
            else
            {
                _counterView.StartCounter();
                _isCounterRunning = true;
            }
        }
    }

    private void UpdateCounterText(int newValue)
    {
        _counterText.text = $"Counter: {newValue}";
    }
}