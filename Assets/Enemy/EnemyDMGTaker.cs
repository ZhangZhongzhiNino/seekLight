using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMGTaker : MonoBehaviour, IEnemyDamageTaker
{
    [field: SerializeField] EnemyConnector c;
    bool takeDMG;
    bool IEnemyDamageTaker.takeDmg{get{ return takeDMG; }}

    // Start is called before the first frame update
    void Start()
    {
        takeDMG = false;
    }

    void IEnemyDamageTaker.TakeDamage()
    {
        takeDMG = true;
        c.animator.Play("Death", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
