using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionHandler : MonoBehaviour
{
    public event Action ActionTriggered;

    [SerializeField] private InputActionReference _inputAction;

    private void OnEnable()
    {
        if (_inputAction != null)
        {
            _inputAction.action.performed += HandleActionPerformed;
            _inputAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (_inputAction != null)
        {
            _inputAction.action.performed -= HandleActionPerformed;
            _inputAction.action.Disable();
        }
    }

    private void HandleActionPerformed(InputAction.CallbackContext context)
    {
        ActionTriggered?.Invoke();
    }
}