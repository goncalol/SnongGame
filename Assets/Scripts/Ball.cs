using System;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject ballController;

    Rigidbody2D rb2d;
    CircleCollider2D cc2d;
    BallController controller;

    void Start ()
    {
        if(ballController!=null)
            controller = ballController.GetComponent<BallController>();

        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();

    }

    public void Init()
    {
        Invoke("GoBall", 1);
    }

    void GoBall()
    {
        cc2d.enabled = true;
        rb2d.AddForce(new Vector2(-20, 3));
    }

    private void Update()
    {
        if (rb2d.velocity.magnitude >= 10) {

            rb2d.velocity -= rb2d.velocity/5;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            controller.BallHitPlayer();
            //Vector2 vel;
            //vel.x = rb2d.velocity.x;
            //vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            //rb2d.velocity = vel;
        }

    }

    public void SetController(BallController ballController)
    {
        controller = ballController;
    }

}
