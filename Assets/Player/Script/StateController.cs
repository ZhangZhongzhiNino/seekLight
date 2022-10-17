using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PStateName
{
    OnIdle,
    OnMove,
    OnAttack,
    OnJump,
    OnSit
}
public class StateController : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SwitchState(string name)
    {
        Connector.instance.FSM.Play(name);
    }
}
