using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallChecker : MonoBehaviour
{
    public UnityEvent hitWall;
    public bool hit;
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hit) return;
        if (collision.tag != Tags.Ground.ToString()) return;
        hit = true;
        hitWall?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != Tags.Ground.ToString()) return;
        hit = true;
        hitWall?.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != Tags.Ground.ToString()) return;
        hit = false;
    }

}
