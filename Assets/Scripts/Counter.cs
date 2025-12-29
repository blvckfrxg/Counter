using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action CountingToggled;
    public event Action<int> CountChanged;

    [SerializeField] private float _countInterval = 0.5f;

    private int _currentCount;
    private bool _isCounting;
    private Coroutine _countingCoroutine;
    private WaitForSeconds _waitInterval;

    private void Awake()
    {
        _waitInterval = new WaitForSeconds(_countInterval);
    }

    public void ToggleCounting()
    {
        _isCounting = !_isCounting;
        CountingToggled?.Invoke();

        if (_isCounting)
        {
            StartCounting();
        }
        else
        {
            StopCounting();
        }
    }

    private void StartCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
        }

        _countingCoroutine = StartCoroutine(CountingRoutine());
    }

    private void StopCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private System.Collections.IEnumerator CountingRoutine()
    {
        while (true)
        {
            yield return _waitInterval;

            _currentCount++;
            CountChanged?.Invoke(_currentCount);
        }
    }
}