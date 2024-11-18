using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _counterValue = 0;
    private bool _isRunning = false;
    private Coroutine _counterCoroutine;

    public int CounterValue => _counterValue;

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
        while (_isRunning)
        {
            yield return new WaitForSeconds(0.5f);
            _counterValue++;
        }
    }
}
