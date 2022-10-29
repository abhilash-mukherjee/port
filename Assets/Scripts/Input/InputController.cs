using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private ShipInputActionMappings shipInputActions;
    private InputAction linearMovementAction, steerMovementAction;
    [SerializeField] private SteerInput steerInput;
    [SerializeField] private LinearInput linearInput;
    [SerializeField] GameEvent hornPressed;
    private InputAction shipInput;
    private void Awake()
    {
        shipInputActions = new ShipInputActionMappings();
    }
    private void OnEnable()
    {
        linearMovementAction = shipInputActions.Ship.LinearMovement;
        steerMovementAction = shipInputActions.Ship.Steer;
        linearMovementAction.Enable();
        steerMovementAction.Enable();
        shipInputActions.Ship.Horn.performed += OnHornPressed;
        shipInputActions.Ship.Horn.Enable();
    }

    private void OnHornPressed(InputAction.CallbackContext obj)
    {
        hornPressed.Raise();
    }

    private void OnDisable()
    {
        linearMovementAction.Disable();
        steerMovementAction.Disable();
        shipInputActions.Ship.Horn.performed -= OnHornPressed;
        shipInputActions.Ship.Horn.Disable();
    }
    private void FixedUpdate()
    {
        linearInput.Value = linearMovementAction.ReadValue<Vector2>().y;
        steerInput.Value = linearInput.Value >= 0 ? steerMovementAction.ReadValue<Vector2>().x : -steerMovementAction.ReadValue<Vector2>().x;
    }
}
