using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IFireInteract
{
    bool fireOn { get; }
    bool interactable { get; }
    void interact();
}
public interface IMakeSound
{
    void makeSound();
}
public interface IHearSound
{
    bool wakeUp { get; }
    void hearSound();
}

public interface IEnemyDamageTaker
{
    bool takeDmg { get; }
    void TakeDamage();
}

public interface IPlayerDamageTaker
{
    bool takeDmg { get; }
    void TakeDamage();
}
public class InterfaceSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
