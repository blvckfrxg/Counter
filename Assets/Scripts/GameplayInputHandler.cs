using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayInputHandler : MonoBehaviour
{
    public event Action PrimaryActionPerformed;

    [SerializeField] private InputActionReference _primaryAction;

    private void OnEnable()
    {
        if (_primaryAction != null)
        {
            _primaryAction.action.performed += OnPrimaryActionPerformed;
            _primaryAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (_primaryAction != null)
        {
            _primaryAction.action.performed -= OnPrimaryActionPerformed;
            _primaryAction.action.Disable();
        }
    }

    private void OnPrimaryActionPerformed(InputAction.CallbackContext context)
    {
        PrimaryActionPerformed?.Invoke();
    }
}