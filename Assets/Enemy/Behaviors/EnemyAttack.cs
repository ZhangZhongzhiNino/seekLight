using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
    EnemyConnector c;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c = animator.GetComponentInParent<EnemyConnector>();

        c.animator.Play("Attack", 0);
        c.ATK.enable = true;
        c.mover.enable = false;
        c.events.ATKfinish.AddListener(toMove);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c.ATK.enable = false;
        c.ATK.PlayerInRange = false;
        c.mover.enable = true;
        c.events.ATKfinish.RemoveListener(toMove);
    }
    void toMove()
    {
        c.animator.Play("Move", 1);
    }
}
