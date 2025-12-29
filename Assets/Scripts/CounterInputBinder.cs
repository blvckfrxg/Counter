using UnityEngine;

public class CounterInputBinder : MonoBehaviour
{
    [SerializeField] private GameplayInputHandler _inputHandler;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        if (_inputHandler != null && _counter != null)
        {
            _inputHandler.PrimaryActionPerformed += OnPrimaryActionPerformed;
        }
    }

    private void OnDisable()
    {
        if (_inputHandler != null && _counter != null)
        {
            _inputHandler.PrimaryActionPerformed -= OnPrimaryActionPerformed;
        }
    }

    private void OnPrimaryActionPerformed()
    {
        _counter.ToggleCounting();
    }
}