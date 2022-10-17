using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDMGTaker : MonoBehaviour, IPlayerDamageTaker
{
    bool takeDmg;
    bool IPlayerDamageTaker.takeDmg { get { return takeDmg; } }
    [field:SerializeField]Connector c;
    [field: SerializeField] float dmgTaking;

    // Start is called before the first frame update
    void Start()
    {
        takeDmg = false;
    }

    void IPlayerDamageTaker.TakeDamage()
    {
        if (takeDmg) return;
        takeDmg = true;
        StartCoroutine(takeDMGCountDown());
        c.HealSystem.TakeDmg(dmgTaking);
    }

    IEnumerator takeDMGCountDown()
    {
        yield return new WaitForSeconds(0.5f);
        takeDmg = false;
    }
}
