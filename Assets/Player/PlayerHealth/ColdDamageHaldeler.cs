using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdDamageHaldeler : MonoBehaviour
{
    [field: SerializeField] Connector c;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (c.FireInL.FireInrage && c.HealSystem.isInCold) c.HealSystem.stopTakeColdDMG();
        if (!c.FireInL.FireInrage && !c.FireInS.FireInrage && !c.HealSystem.isInCold) c.HealSystem.startTakeColdDMG();
        bool isInsit = c.FSM.GetCurrentAnimatorStateInfo(0).IsName(PStateName.OnSit.ToString());
        if (isInsit && c.FireInS.FireInrage && !c.HealSystem.isInHeal) c.HealSystem.startHeal();
        if (!isInsit && c.HealSystem.isInHeal) c.HealSystem.stopHeal();
    }
}
