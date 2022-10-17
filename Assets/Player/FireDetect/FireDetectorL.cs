using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireDetectorL : MonoBehaviour
{
    [field: SerializeField] public bool FireInrage { get; private set; }
    List<Collider2D> collisions;

    void Start()
    {
        FireInrage = false;
        collisions = new List<Collider2D>();
    }

    private void FixedUpdate()
    {
        detectFire();
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
    void detectFire()
    {
        FireInrage = false;
        if (collisions.Count == 0) return;
        foreach (Collider2D c in collisions)
        {
            IFireInteract f = c.GetComponent<IFireInteract>();
            if (f == null) continue;
            if (!f.fireOn) continue;
            FireInrage = true;
        }
    }
}
