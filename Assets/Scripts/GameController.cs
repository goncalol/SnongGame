using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject score;
    public GameObject player;
    public GameObject ball;
    public GameObject SnakeLengthBtn;
    public GameObject PauseBtn;
    public Sprite PlayTexture;
    public Sprite PauseTexture;
    public GameObject SoundBtn;
    public Sprite SoundOnTexture;
    public Sprite SoundOffTexture;
    public AudioSource HitSound;
    public AudioSource FailSound;
    public GameObject StartText;

    ScoreController scoreController;
    PlayerController playerController;
    BallController ballController;
    Button SnakeLenghtBTN;
    Button PauseBTN;
    Button SoundBTN;
    bool SoundOn;
    bool GameInit;

    int NumberOfSnakeLength = 0;

    void Start () {

        //AdManager.Instance.ShowBanner();
        SoundOn = true;
        SoundBTN = SoundBtn.GetComponent<Button>();
        PauseBTN = PauseBtn.GetComponent<Button>();
        SnakeLenghtBTN = SnakeLengthBtn.GetComponent<Button>();
        scoreController = score.GetComponent<ScoreController>();
        playerController = player.GetComponent<PlayerController>();
        ballController = ball.GetComponent<BallController>();
    }

    private void Update()
    {
        if (!GameInit) {
            var down = Input.GetMouseButtonDown(0);
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);            
            if (down && mousePos.y <= 3.5f)
            {
                Destroy(StartText);
                GameInit = true;
                playerController.Move();
                ballController.ApplyForce();
            }
        }
    }

    public void BallHitPlayer()
    {
        if(SoundOn) HitSound.Play();
        scoreController.IncreasePoints();
    }

    public void BallOutside(Ball ball)
    {
        if (SoundOn) FailSound.Play();
        ballController.DestroyAll();
        playerController.StopInteraction();
        scoreController.ShowEndGame();
    }

    public void RestartBtnClicked()
    {
        ballController.CreateNew();
        playerController.ResetPosition();
        scoreController.ResetScore();
    }

    public void First24()
    {
        ballController.IncreaseBounce25();
    }    

    public void First25()
    {
        //ballController.CreateNew();
        playerController.IncreaseSpeed25();
    }

    public void First49()
    {
        ballController.IncreaseBounce50();
    }

    public void First50()
    {
        playerController.IncreaseSpeed50();
    }

    private bool isGamePaused = false;
    private float timeScale;
    public void PauseGame() {
        if (!isGamePaused)
        {
            timeScale = Time.timeScale;
            Time.timeScale = 0;
            isGamePaused = true;
            PauseBTN.GetComponent<Image>().sprite= PlayTexture;
        }
        else
        {
            Time.timeScale = timeScale;
            isGamePaused = false;
            PauseBTN.GetComponent<Image>().sprite= PauseTexture;
        }
    }

    public void ToggleSound()
    {
        SoundOn = !SoundOn;
        if (SoundOn)
        {
            SoundBTN.GetComponent<Image>().sprite = SoundOnTexture;
        }
        else
        {
            SoundBTN.GetComponent<Image>().sprite = SoundOffTexture;
        }
    }

    public void OnMainMenuClick() {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnSnakeLengthClick() {

        if ((NumberOfSnakeLength++) < 5) {
            
            playerController.IncreaseLength();
        }
        else
        {
            SnakeLenghtBTN.interactable = false;
        }

    }

    public void OnSpeedIncreaseClick() {
        playerController.IncreaseSpeed();
    }

    public void OnSpeedDecreaseClick()
    {
        playerController.DecreaseSpeed();
    }

    public void OnSnakeLengthBUYClick()
    {
        IAPManager.Instance.BuyNonConsumable();
    }
}
