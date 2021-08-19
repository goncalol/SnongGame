using System;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject game;
    public PhysicsMaterial2D bounce_25;
    public PhysicsMaterial2D bounce_50;
    public GameObject initialBall;
    public GameObject prefabBall;

    GameController gameController;
    List<GameObject> BallsList;

    void Start () {
        BallsList = new List<GameObject>();
        BallsList.Add(initialBall);
        gameController = game.GetComponent<GameController>();
    }

    public void BallHitPlayer()
    {
        gameController.BallHitPlayer();
    }

    public void DestroyAll()
    {
        foreach (var ball in BallsList) {
            Destroy(ball);
        }
        BallsList = new List<GameObject>();
    }

    public void CreateNew()
    {
        var newBall = Instantiate(prefabBall);
        var ballComponent = newBall.GetComponent<Ball>();
        ballComponent.SetController(this);
        BallsList.Add(newBall);
        ballComponent.Init();
    }

    public void IncreaseBounce25()
    {
        foreach (var ball in BallsList)
        {
            ball.GetComponent<CircleCollider2D>().sharedMaterial = bounce_25;
        }
    }

    public void IncreaseBounce50()
    {
        foreach (var ball in BallsList)
        {
            ball.GetComponent<CircleCollider2D>().sharedMaterial = bounce_50;
        }
    }

    public void ApplyForce()
    {
        foreach (var ball in BallsList)
        {
            ball.GetComponent<Ball>().Init();
        }
    }
}
