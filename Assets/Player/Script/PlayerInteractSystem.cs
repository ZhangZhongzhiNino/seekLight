using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractSystem : MonoBehaviour
{
    [field: SerializeField] public Connector c;
    List<Collider2D> collisions;
    private void Awake()
    { 
        collisions = new List<Collider2D>();
    }
    private void OnEnable()
    {
        c.ICgesture.doubleTap.AddListener(tryInteract);
    }
    private void OnDisable()
    {
        c.ICgesture.doubleTap.RemoveListener(tryInteract);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != Tags.Fire.ToString()) return;
        if (!collisions.Contains(collision)) collisions.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != Tags.Fire.ToString()) return;
        if (collisions.Contains(collision)) collisions.Remove(collision);
    }

    void tryInteract()
    {
        if (collisions.Count == 0) return;
        foreach(Collider2D c in collisions)
        {
            IFireInteract fireInteract = c.GetComponent<IFireInteract>();
            if (fireInteract == null) continue;
            fireInteract.interact();
        }
    }
}
