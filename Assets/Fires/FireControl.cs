using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireControl : MonoBehaviour, IFireInteract
{
    [field: SerializeField] public GameObject Fire { get; private set; }

    [field: SerializeField] public bool interactable { get; private set; }
    bool IFireInteract.fireOn { get { return Fire.active; } }
    bool IFireInteract.interactable { get { return interactable; } }

    void IFireInteract.interact()
    {
        if (!interactable) return;
        Fire.SetActive(!Fire.active);
    }

    void Start()
    {
    }
    void Update()
    {
    }
}
