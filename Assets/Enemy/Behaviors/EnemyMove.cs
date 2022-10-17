using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : StateMachineBehaviour
{
    EnemyConnector c;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c = animator.GetComponentInParent<EnemyConnector>();

        c.animator.Play("Run", 0);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (c.ATK.PlayerInRange) c.animator.Play("ATK");
    }
}
