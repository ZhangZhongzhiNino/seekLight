using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSitState : StateMachineBehaviour
{
    Connector c;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        c = Connector.instance;
        if (!c.GroundCheck.hit) toIdle();
        c.rb2d.velocity = Vector2.zero;
        c.ICgesture.enable = true;
        c.AniControl.StartAni(PAniName.SitDownToFire.ToString());
        c.AniEvent.sitDownFinish.AddListener(startSitAnimation);
        c.ICgesture.SlideUp.AddListener(startStandUp);
        c.AniEvent.standUpFinish.AddListener(toIdle);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c.ICgesture.enable = false;
        c.AniEvent.sitDownFinish.RemoveListener(startSitAnimation);
        c.ICgesture.SlideUp.RemoveListener(startStandUp);
        c.AniEvent.standUpFinish.RemoveListener(toIdle);
    }


    void startSitAnimation()
    {
        c.AniControl.StartAni(PAniName.SitByTheFire.ToString());
    }
    void startStandUp()
    {
        c.AniControl.StartAni(PAniName.WalkAwayFromFire.ToString());
    }
    void toIdle()
    {
        c.StateControl.SwitchState(PStateName.OnIdle.ToString());
    }
}
