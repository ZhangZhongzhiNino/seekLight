using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListener : MonoBehaviour,IHearSound
{
    [field: SerializeField] EnemyConnector c;
    bool wake;
    public bool wakeUp { get { return wake; } }

    public void hearSound()
    {
        wake = true;
        c.mover.enable = true;
        c.animator.Play("Move", 1);
    }

    void Start()
    {
        wake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
