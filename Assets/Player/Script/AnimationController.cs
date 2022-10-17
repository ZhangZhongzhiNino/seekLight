using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PAniName
{
    Idle, Run, Death,
    SitDownToFire, SitByTheFire, WalkAwayFromFire,
    Punch,
    OpenedBag,
    FlyUp,
    FlyDown
}
public class AnimationController : MonoBehaviour
{
    private void Awake()
    {
        
    }
    void Start()
    {
    }

    void Update(){ }

    public void StartAni(string animationName)
    {
        Connector.instance.animator.Play(animationName);
        
    }
}
