using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttackInterface : MonoBehaviour
{
    public bool enable;
    void Start()
    {
        enable = false;
    }

    void Update() { }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!enable) return;
        IEnemyDamageTaker Enemy = collision.gameObject.GetComponent<IEnemyDamageTaker>();
        if(Enemy != null)
        {
            Enemy.TakeDamage();
        }
    }
}
