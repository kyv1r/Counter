using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private Counter counter;

    private bool isCounterRunning = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isCounterRunning)
            {
                counter.StopCounter();
                isCounterRunning = false;
            }
            else
            {
                counter.StartCounter();
                isCounterRunning = true;
            }
        }

        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        if (counterText != null)
        {
            counterText.text = $"Counter: {counter.CounterValue}";
        }
    }
}