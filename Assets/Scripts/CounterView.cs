using System.Collections;
using UnityEngine;
using System;

public class CounterView : MonoBehaviour
{
    private int _counterValue = 0;
    private bool _isRunning = false;

    private Coroutine _counterCoroutine;

    public event Action<int> CounterChanged;

    public void StartCounter()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _counterCoroutine = StartCoroutine(IncreaseCounter());
        }
    }

    public void StopCounter()
    {
        if (_isRunning)
        {
            _isRunning = false;

            if (_counterCoroutine != null)
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
        }
    }

    private IEnumerator IncreaseCounter()
    {
        float _delay = 0.5f;

        while (_isRunning)
        {
            yield return new WaitForSeconds(_delay);
            _counterValue++;
            CounterChanged?.Invoke(_counterValue);
        }
    }
}
