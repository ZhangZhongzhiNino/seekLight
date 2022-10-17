using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConnector : MonoBehaviour
{
    [field: SerializeField] public Rigidbody2D rb2d;
    [field: SerializeField] public EnemyMover mover;
    [field: SerializeField] public EnemyAttacker ATK;
    [field: SerializeField] public Animator animator;
    [field: SerializeField] public EnemyAniEvents events;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
