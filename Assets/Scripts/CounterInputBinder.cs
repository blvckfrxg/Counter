using UnityEngine;

public class CounterInputBinder : MonoBehaviour
{
    [SerializeField] private InputActionHandler _inputActionHandler;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        if (_inputActionHandler != null && _counter != null)
        {
            _inputActionHandler.ActionTriggered += HandleActionTriggered;
        }
    }

    private void OnDisable()
    {
        if (_inputActionHandler != null && _counter != null)
        {
            _inputActionHandler.ActionTriggered -= HandleActionTriggered;
        }
    }

    private void HandleActionTriggered()
    {
        _counter.ToggleCounting();
    }
}