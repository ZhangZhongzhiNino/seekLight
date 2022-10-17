using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : StateMachineBehaviour
{
    Connector c;
    bool moveInputOn;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c = Connector.instance;
        moveInputOn = false;

        c.Mover.enable = true;
        c.AniControl.StartAni(PAniName.Punch.ToString());
        c.AniEvent.attackDMGStart.AddListener(startDealDMG);
        c.AniEvent.attackDMGFinish.AddListener(stopDealDMG);
        c.AniEvent.attackMoveOn.AddListener(openMoveInput);
        c.AniEvent.attackFinish.AddListener(toIdle);
        c.ICgesture.SlideUp.AddListener(toJump);
        c.ICmove.startRunning.AddListener(toMove);
        c.ICmove.startWalking.AddListener(toMove);

        c.SoundL.tryMakeSound();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!moveInputOn) return;
        if (!c.ICmove.isMoving) return;
        c.StateControl.SwitchState(PStateName.OnMove.ToString());
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c.Mover.enable = false;
        c.PlayerAttack.enable = false;
        c.AniEvent.attackDMGStart.RemoveListener(startDealDMG);
        c.AniEvent.attackDMGFinish.RemoveListener(stopDealDMG);
        c.AniEvent.attackMoveOn.RemoveListener(openMoveInput);
        c.AniEvent.attackFinish.RemoveListener(toIdle);
        c.ICgesture.SlideUp.RemoveListener(toJump);
        c.ICmove.startRunning.RemoveListener(toMove);
        c.ICmove.startWalking.RemoveListener(toMove);
    }
    void openMoveInput()
    {
        moveInputOn = true;
    }
    void toIdle()
    {
        c.StateControl.SwitchState(PStateName.OnIdle.ToString());
    }
    void toMove()
    {
        if (!moveInputOn) return;
        c.StateControl.SwitchState(PStateName.OnMove.ToString());
    }
    void toJump()
    {
        if (!moveInputOn) return;
        c.StateControl.SwitchState(PStateName.OnJump.ToString());
    }

    void startDealDMG()
    {
        c.PlayerAttack.enable = true;
    }
    void stopDealDMG()
    {
        c.PlayerAttack.enable = true;
    }
}
