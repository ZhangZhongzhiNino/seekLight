using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    public bool enable;
    public bool PlayerInRange;
    void Start()
    {
        enable = false;
        PlayerInRange = false;
    }

    void Update() { }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player") PlayerInRange = true;
        if (!enable) return;
        IPlayerDamageTaker Enemy = collision.gameObject.GetComponentInChildren<IPlayerDamageTaker>();
        if (Enemy != null)
        {
            Enemy.TakeDamage();
        }
    }
}
