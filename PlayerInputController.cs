using UnityEngine;
using System;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

public class PlayerInputController : MonoBehaviour
{
    public event Action<float> OnMoveEnvet;
    public event Action<float> OnMove2Envet;

    public void CallMoveEvent(float axis)
    {
        OnMoveEnvet?.Invoke(axis);
    }
    public void CallMove2Event(float axis)
    {
        OnMove2Envet?.Invoke(axis);
    }

    public void OnMove(InputValue value)
    {
        float axis = value.Get<float>();

        CallMoveEvent(axis);
    }
    public void OnMove2(InputValue value)
    {
        float axis = value.Get<float>();

        CallMove2Event(axis);
    }
}
