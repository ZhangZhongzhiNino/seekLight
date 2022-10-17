using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : StateMachineBehaviour
{
    Connector c;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c = Connector.instance;


        c.ICgesture.enable = true;
        
        if (c.GroundCheck.hit)
        {
            Vector2 v = c.rb2d.velocity;
            v.x = 0;
            c.rb2d.velocity = v;
        }
        c.AniControl.StartAni(PAniName.Idle.ToString());

        c.ICmove.startWalking.AddListener(startMove);
        c.ICgesture.SlideL.AddListener(attackL);
        c.ICgesture.SlideR.AddListener(attackR);
        c.ICgesture.SlideDown.AddListener(Sitdown);
        c.ICgesture.SlideUp.AddListener(Jump);

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (c.ICmove.isMoving) startMove();
        if (!c.GroundCheck.hit) c.StateControl.SwitchState(PStateName.OnJump.ToString());
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c.ICgesture.enable = false;
        c.ICmove.startWalking.RemoveListener(startMove);
        c.ICgesture.SlideL.RemoveListener(attackL);
        c.ICgesture.SlideR.RemoveListener(attackR);
        c.ICgesture.SlideDown.RemoveListener(Sitdown);
        c.ICgesture.SlideUp.RemoveListener(Jump);
    }
    void startMove()
    {
        
        c.StateControl.SwitchState(PStateName.OnMove.ToString());
    }
    void attackL()
    {
        c.Facing.transform.rotation = Quaternion.Euler(0,180,0);
        c.StateControl.SwitchState(PStateName.OnAttack.ToString());
    }
    void attackR()
    {
        c.Facing.transform.rotation = Quaternion.Euler(0, 0, 0);
        c.StateControl.SwitchState(PStateName.OnAttack.ToString());
    }
    void Sitdown()
    {
        if (!c.GroundCheck.hit) return;
        c.StateControl.SwitchState(PStateName.OnSit.ToString());
    }
    void Jump()
    {
        if (!c.GroundCheck.hit) return;
        c.StateControl.SwitchState(PStateName.OnJump.ToString());
    }
}
