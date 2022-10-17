using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMoveControl : MonoBehaviour
{
    InputControl IC;
    // public value in
    [field: SerializeField] public float RunDis { get; private set; }
    [field: SerializeField] public float WalkDis { get; private set; }
    // Public value out
    [field: SerializeField] public Vector2 moveDirection { get; private set; }
    [field: SerializeField] public bool isMoving { get; private set; }
    [field: SerializeField] private int _moveType;
    [field:SerializeField] public Vector2 turnDirection { get; private set; }
    public int moveType
    {
        get { return _moveType; }
        set 
        { 
            if (value != _moveType)
            {
                if (value == -1)
                {
                    if (_moveType == 0) stopWalk?.Invoke();
                    if(_moveType==1) stopRun?.Invoke();
                }
                else if (value == 0) startWalking?.Invoke();
                else if (value == 1) startRunning?.Invoke();
            }
            _moveType = value;
        }
    }
    public UnityEvent stopWalk;
    public UnityEvent stopRun;
    public UnityEvent startWalking;
    public UnityEvent startRunning;
    void Awake()
    {
        IC = GetComponent<InputControl>();
        SetUpValue();
    }

    void SetUpValue()
    {
        moveDirection = Vector2.zero;
        turnDirection = Vector2.zero;
        isMoving = false;
        moveType = -1;
    }

    public void TrySetMove()
    {
        if (IC.fingerRule[0] == 0)
        {
            isMoving = true;
            Vector2 Difference = IC.fingerLocation[0] - IC.fingerStartLocation[0];
            Difference.y = 0;
            turnDirection = Difference.normalized;
            float FingerMoveDis = Difference.magnitude;
            if (FingerMoveDis < WalkDis)
            {
                moveType = -1;
                isMoving = false;
                moveDirection = Vector2.zero;
            }
            else
            {
                if (FingerMoveDis >= WalkDis && FingerMoveDis <= RunDis) moveType = 0;
                if (FingerMoveDis > RunDis) moveType = 1;
                moveDirection = Difference.normalized;
            }
            
            
        }else if (IC.fingerRule[1] == 0)
        {
            isMoving = true;
            Vector2 Difference = IC.fingerLocation[1] - IC.fingerStartLocation[1];
            Difference.y = 0;
            turnDirection = Difference.normalized;
            float FingerMoveDis = Difference.magnitude;
            if (FingerMoveDis < WalkDis)
            {
                moveType = -1;
                isMoving = true;
                moveDirection = Vector2.zero;
            }
            else
            {
                if (FingerMoveDis >= WalkDis && FingerMoveDis <= RunDis) moveType = 0;
                if (FingerMoveDis > RunDis) moveType = 1;
                moveDirection = Difference.normalized;
            }
        }
    }
    public void TryClearMove()
    {
        if (IC.fingerRule[0] == 0 || IC.fingerRule[1] == 0) return;
        isMoving = false;
        moveDirection = Vector2.zero;
        moveType = -1;
    }
}
