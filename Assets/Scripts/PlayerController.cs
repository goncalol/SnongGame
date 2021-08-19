using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Player;
    public GameObject game;
    public GameObject InsertStart;
    public GameObject InsertEnd;
    public GameObject BodyPartPrefab;

    SnakeMovement snake;
    Vector2 InitialPosition;
    GameController gameController;

    bool IsInteractiveMode;
    bool IsLeftActive;
    bool IsRightActive;

    void Start ()
    {
        InitialPosition = new Vector2(0.36f,-4.63f);
        snake = Player.GetComponent<SnakeMovement>();
        gameController = game.GetComponent<GameController>();
       // IsInteractiveMode = true;
    }

    void Update()
    {
        if (IsInteractiveMode)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.y >= 3.5f) {
                if (IsLeftActive)
                {
                    snake.speed += 2;
                    IsLeftActive = false;
                }
                else if (IsRightActive)
                {
                    snake.speed -= 5;
                    IsRightActive = false;
                }
            }

            if (Input.GetMouseButtonDown(0) && mousePos.x<=0 && !IsRightActive) {//slow
                snake.speed -=2;
                IsLeftActive = true;
            }
            if (Input.GetMouseButtonUp(0) && IsLeftActive)
            {
                snake.speed +=2;
                IsLeftActive = false;
            }

            if (Input.GetMouseButtonDown(0) && mousePos.x > 0 && !IsLeftActive){//fast
                snake.speed += 5;
                IsRightActive = true;
            }
            if (Input.GetMouseButtonUp(0) && IsRightActive)
            {
                snake.speed -= 5;
                IsRightActive = false;
            }           
        }
    }

    public void IncreaseLength()
    {
        var nbp = Instantiate(BodyPartPrefab);
        nbp.transform.position = InsertEnd.transform.position;
        var newBodyPart = nbp.GetComponent<BodyPart>();
        newBodyPart.SetNext(InsertEnd);
        InsertStart.GetComponent<BodyPart>().SetNext(nbp);

        InsertStart = nbp;
    }

    public void IncreaseSpeed25()
    {
        snake.speed +=3;
    }

    public void IncreaseSpeed50()
    {
        snake.speed += 3;
    }

    public void IncreaseSpeed()
    {
        snake.speed ++;
    }

    public void DecreaseSpeed()
    {
        if(snake.speed>=4)
            snake.speed --;
    }

    public void ResetPosition()
    {
        snake.speed = 4;
        IsInteractiveMode = true;
        snake.SetPosition(InitialPosition);
        snake.SetMoving(true);
    }

    public void Move()
    {
        IsInteractiveMode = true;
        snake.SetMoving(true);
    }

    public void StopInteraction() {
        IsRightActive = false;
        IsLeftActive = false;
        IsInteractiveMode = false;
        snake.SetMoving(false);
    }
}
