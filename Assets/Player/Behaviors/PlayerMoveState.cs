using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : StateMachineBehaviour
{
    Connector c;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c = Connector.instance;
        c.Mover.enable = true;
        c.ICgesture.enable = true;
        c.AniControl.StartAni(PAniName.Run.ToString());

        c.ICgesture.SlideUp.AddListener(Jump);
        c.ICgesture.SlideDown.AddListener(SitDown);
        c.ICgesture.SlideR.AddListener(attackR);
        c.ICgesture.SlideL.AddListener(attackL);
        c.ICmove.stopWalk.AddListener(toIdle);
        c.ICmove.stopRun.AddListener(toIdle);
        c.WallCheck.hitWall.AddListener(toIdle);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        faceMovementDirection();
        if (!c.ICmove.isMoving) toIdle();
        if (c.ICmove.moveType == -1) toIdle();
        if (!c.GroundCheck.hit) c.StateControl.SwitchState(PStateName.OnJump.ToString());
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c.Mover.enable = false;
        c.ICgesture.enable = false;
        c.ICgesture.SlideUp.RemoveListener(Jump);
        c.ICgesture.SlideDown.RemoveListener(SitDown);
        c.ICgesture.SlideR.RemoveListener(attackR);
        c.ICgesture.SlideL.RemoveListener(attackL);
        c.ICmove.stopWalk.RemoveListener(toIdle);
        c.ICmove.stopRun.RemoveListener(toIdle);
        c.WallCheck.hitWall.RemoveListener(toIdle);

        c.SoundS.tryMakeSound();
    }

    void faceMovementDirection()
    {
        if (c.ICmove.turnDirection == new Vector2(-1, 0)) 
            c.Facing.transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (c.ICmove.turnDirection == new Vector2(1, 0))
            c.Facing.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void toIdle()
    {
        c.StateControl.SwitchState(PStateName.OnIdle.ToString());
    }
    void attackL()
    {
        c.Facing.transform.rotation = Quaternion.Euler(0, 180, 0);
        c.StateControl.SwitchState(PStateName.OnAttack.ToString());
    }
    void attackR()
    {
        c.Facing.transform.rotation = Quaternion.Euler(0, 0, 0);
        c.StateControl.SwitchState(PStateName.OnAttack.ToString());
    }
    void SitDown()
    {
        c.StateControl.SwitchState(PStateName.OnSit.ToString());
    }
    void Jump()
    {
        c.StateControl.SwitchState(PStateName.OnJump.ToString());
    }

}
