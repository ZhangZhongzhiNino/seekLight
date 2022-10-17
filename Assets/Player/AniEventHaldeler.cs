using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AniEventHaldeler : MonoBehaviour
{
    public UnityEvent attackDMGStart;
    public UnityEvent attackDMGFinish;
    public UnityEvent attackMoveOn;
    public UnityEvent attackFinish;

    public void AttackDMGStart() => attackDMGStart?.Invoke();
    public void AttackDMGFinish() => attackDMGFinish?.Invoke();
    public void AttackMoveOn() => attackMoveOn?.Invoke();
    public void AttackFinish() => attackFinish?.Invoke();

    public UnityEvent sitDownFinish;
    public UnityEvent standUpFinish;

    public void SitDownFinish() => sitDownFinish?.Invoke();
    public void StandUpFinish() => standUpFinish?.Invoke();


    void Start() { }
    void Update() { }
    

}
