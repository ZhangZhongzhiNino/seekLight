using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFunction : MonoBehaviour
{
    //private setting
    InputControl IC;

    //public value
    private void Awake()
    {
        IC = GetComponent<InputControl>();
    }
    private void Start()
    {
        
        
    }

    public void MarkStartLocation_AssignRule0()
    {
        IC.fingerStartLocation[0] = IC.fingerLocation[0];
        if (IC.fingerStartLocation[0].x < (Screen.width / 2))
        {
            IC.fingerRule[0] = 0;
        }else if(IC.fingerStartLocation[0].x >= (Screen.width / 2))
        {
            IC.fingerRule[0] = 1;
        }
    }
    public void MarkStartLocation_AssignRule1()
    {
        IC.fingerStartLocation[1] = IC.fingerLocation[1];
        if (IC.fingerStartLocation[1].x < (Screen.width / 2))
        {
            IC.fingerRule[1] = 0;
        }
        else if (IC.fingerStartLocation[1].x >= (Screen.width / 2))
        {
            IC.fingerRule[1] = 1;
        }
    }
    public void ClearFingerRule0()
    {
        IC.fingerRule[0] = -1;
    }
    public void ClearFingerRule1()
    {
        IC.fingerRule[1] = -1;
    }
}
