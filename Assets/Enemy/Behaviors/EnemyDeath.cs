using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : StateMachineBehaviour
{
    EnemyConnector c;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        c = animator.GetComponentInParent<EnemyConnector>();

        c.animator.Play("Death", 0);
        c.ATK.enable = false;
        c.mover.enable = false;
    }
}
