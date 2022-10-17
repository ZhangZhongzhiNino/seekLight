using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputControl : MonoBehaviour, PlayerInput.ITouchActions
{
    //private settings
    private PlayerInput Pinput;

    //public settings
    public UnityEvent Tap0Event;
    public UnityEvent Tap1Event;
    public UnityEvent OnFinger0;
    public UnityEvent OnFinger1;
    public UnityEvent OnFingerLeave0;
    public UnityEvent OnFingerLeave1;
    public UnityEvent FingerMove0;
    public UnityEvent FingerMove1;

    //public value
    [field : SerializeField] public Vector2[] fingerLocation { get; private set; }
    [field : SerializeField] public bool[] fingerOn { get; private set; }
    [field : SerializeField] public Vector2 lastTapLocation { get; private set; }

    [field : SerializeField] public Vector2[] fingerStartLocation;
    [field : SerializeField] public int[] fingerRule;
    [field : SerializeField] public Vector2[] deltaLocation { get; private set; }

    private void Start()
    {
        StartCallBack();
        SetUpValues();
    }
    void StartCallBack()
    {
        Pinput = new PlayerInput();
        Pinput.Touch.SetCallbacks(this);
        Pinput.Touch.Enable();
    }
    void SetUpValues()
    {
        fingerLocation = new Vector2[2];
        fingerLocation[0] = Vector2.zero;
        fingerLocation[1] = Vector2.zero;

        fingerOn = new bool[2];
        fingerOn[0] = false;
        fingerOn[1] = false;

        lastTapLocation = Vector2.zero;

        fingerStartLocation = new Vector2[2];
        fingerStartLocation[0] = Vector2.zero;
        fingerStartLocation[1] = Vector2.zero;

        fingerRule = new int[2];
        fingerRule[0] = -1;
        fingerRule[1] = -1;

        deltaLocation = new Vector2[2];
        deltaLocation[0] = Vector2.zero;
        deltaLocation[1] = Vector2.zero;
    }

    void PlayerInput.ITouchActions.OnFinger0(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        
        if (!context.performed) 
        {
            if(context.phase == UnityEngine.InputSystem.InputActionPhase.Canceled)
            {
                fingerOn[0] = false;
                OnFingerLeave0?.Invoke();
            }
            return;
        } 
        fingerOn[0] = true;
        OnFinger0?.Invoke();
    }

    void PlayerInput.ITouchActions.OnFinger1(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            if (context.phase == UnityEngine.InputSystem.InputActionPhase.Canceled)
            {
                fingerOn[1] = false;
                OnFingerLeave1?.Invoke();
            }
                
            return;
        }
        fingerOn[1] = true;
        OnFinger1?.Invoke();
    }

    void PlayerInput.ITouchActions.OnLocation0(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (fingerLocation[0] != Vector2.zero) deltaLocation[0] = context.ReadValue<Vector2>() - fingerLocation[0];
        fingerLocation[0] = context.ReadValue<Vector2>();
        
        FingerMove0?.Invoke();
    }

    void PlayerInput.ITouchActions.OnLocation1(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (fingerLocation[1] != Vector2.zero) deltaLocation[1] = context.ReadValue<Vector2>() - fingerLocation[1];
        fingerLocation[1] = context.ReadValue<Vector2>();
        FingerMove1?.Invoke();
    }

    void PlayerInput.ITouchActions.OnTap0(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        lastTapLocation = fingerLocation[0];
        Tap0Event?.Invoke();
    }

    void PlayerInput.ITouchActions.OnTap1(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        lastTapLocation = fingerLocation[1];
        Tap1Event?.Invoke();
    }
}
