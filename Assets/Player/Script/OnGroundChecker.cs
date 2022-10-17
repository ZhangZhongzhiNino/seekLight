using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnGroundChecker : MonoBehaviour
{
    public UnityEvent hitGround;
    public bool hit;
    void Start()
    {
        hit = false;
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hit) return;
        if (collision.tag != Tags.Ground.ToString()) return;
        hit = true;
        hitGround?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != Tags.Ground.ToString()) return;
        hit = true;
        hitGround?.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != Tags.Ground.ToString()) return;
        hit = false;
    }
}
