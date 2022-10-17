using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [field: SerializeField] EnemyConnector c;
    [field: SerializeField] float runForce;
    [field: SerializeField] float maxSpeed;
    public bool enable;
    Vector2 moveDirection;
    void Start()
    {
        enable = false;
    }

    void FixedUpdate()
    {
        if (!enable) return;
        moveDirection = new Vector2(Connector.instance.transform.position.x - transform.position.x, 0);
        movePlayer();
    }
    void movePlayer()
    {

        c.rb2d.AddForce(moveDirection.normalized * runForce * Time.fixedDeltaTime);
        if (OnMaxSpeed()) c.rb2d.AddForce(-moveDirection.normalized * runForce * Time.fixedDeltaTime);
        faceMoveDirection();


    }
    bool OnMaxSpeed()
    {
        if (Mathf.Abs(c.rb2d.velocity.x) >= maxSpeed) return true;
        else return false;
    }
    void faceMoveDirection()
    {
        if (moveDirection.x < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (moveDirection.x > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
