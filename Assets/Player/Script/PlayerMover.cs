using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [field: SerializeField] float walkForce;
    [field: SerializeField] float runForce;
    [field: SerializeField] float maxSpeed;
    [field: SerializeField] float jumpForce;
    public bool enable;
    Connector c;
    void Start()
    {
        enable = false;
        c = Connector.instance;
    }

    void FixedUpdate()
    {
        if (!enable) return;
        if (c.ICmove.isMoving != true) return;
        if (c.ICmove.moveType == -1) return;
        movePlayer();
    }
    void movePlayer()
    {
        if (c.ICmove.moveType == 0)
        {
            c.rb2d.AddForce(c.ICmove.moveDirection * walkForce * Time.fixedDeltaTime);
            if (OnMaxSpeed()) c.rb2d.AddForce(-c.ICmove.moveDirection * walkForce * Time.fixedDeltaTime);
        }
            
        else if (c.ICmove.moveType == 1)
        {
            c.rb2d.AddForce(c.ICmove.moveDirection * runForce * Time.fixedDeltaTime);
            if (OnMaxSpeed()) c.rb2d.AddForce(-c.ICmove.moveDirection * runForce * Time.fixedDeltaTime);
        }
           
        
    } 
    bool OnMaxSpeed()
    {
        if (Mathf.Abs(c.rb2d.velocity.x)  >= maxSpeed) return true;
        else return false;
    }

    public void Jump()
    {
        Vector2 v = c.rb2d.velocity;
        v.y = jumpForce;
        c.rb2d.velocity = v;
    }
    public void ForceDown()
    {
        Vector2 v = c.rb2d.velocity;
        v.y = -jumpForce;
        c.rb2d.velocity = v;
    }
}
 