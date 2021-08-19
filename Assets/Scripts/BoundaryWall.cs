using UnityEngine;

public class BoundaryWall : MonoBehaviour {

    public GameObject game;
    GameController gameController;

    void Start ()
    {
        gameController = game.GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ball") {

            gameController.BallOutside(collider.GetComponentInParent<Ball>());
        }
    }
}
