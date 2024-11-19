using TMPro;
using UnityEngine;
using System;
public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Counter _counter;

    private bool _isCounterRunning = false;

    private void OnEnable()
    {
        _counter.CounterChanged += UpdateCounterText;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= UpdateCounterText;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounterRunning)
            {
                _counter.StopCounter();
                _isCounterRunning = false;
            }
            else
            {
                _counter.StartCounter();
                _isCounterRunning = true;
            }
        }
    }

    private void UpdateCounterText(int newValue)
    {
        if (_counterText != null)
        {
            _counterText.text = $"Counter: {newValue}";
        }
    }
}