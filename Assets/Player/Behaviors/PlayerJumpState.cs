using UnityEngine;

public class PlayerJumpState : StateMachineBehaviour
{
    Connector c;
    bool goUp;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c = Connector.instance;
        goUp = true;
        c.ICgesture.enable = true;
        c.Mover.enable = true;
        c.AniControl.StartAni(PAniName.FlyUp.ToString());
        if(c.GroundCheck.hit) c.Mover.Jump();

        c.GroundCheck.hitGround.AddListener(toIdle);
        c.ICgesture.SlideL.AddListener(attackL);
        c.ICgesture.SlideR.AddListener(attackR);
        c.ICgesture.SlideDown.AddListener(forceDown);

        c.SoundL.tryMakeSound();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (c.GroundCheck.hit) toIdle();
        if (!goUp) return;
        if (c.rb2d.velocity.y < 0)
        {
            goUp = false;
            c.AniControl.StartAni(PAniName.FlyDown.ToString());
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c.ICgesture.enable = false;
        c.Mover.enable = false;
        c.GroundCheck.hitGround.RemoveListener(toIdle);
        c.ICgesture.SlideL.RemoveListener(attackL);
        c.ICgesture.SlideR.RemoveListener(attackR);
        c.ICgesture.SlideDown.RemoveListener(forceDown);
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
    void forceDown()
    {
        c.Mover.ForceDown();
    }
}
