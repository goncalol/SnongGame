using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public GameObject Game;
    public GameObject CurrentScoreDisplay;
    public GameObject EndGamePanel;

    int currentScore = 0;
    int highestScore;

    Text scoreText;
    GameController gameController;
    Animator scoreAnimator;

    void Start()
    {
        scoreAnimator = EndGamePanel.GetComponent<Animator>();
        gameController = Game.GetComponent<GameController>();
        scoreText = CurrentScoreDisplay.GetComponent<Text>();
        scoreText.text = "" + currentScore;
        LoadPlayerProgress();
    }

    public void IncreasePoints()
    {
        currentScore++;
        scoreText.text = "" + currentScore;
        if (currentScore == 24)
        {
            gameController.First24();
        }
        else if (currentScore == 25)
        {
            gameController.First25();
        }
        else if (currentScore == 49)
        {
            gameController.First49();
        }
        else if (currentScore == 50)
        {
            gameController.First50();
        }
    }

    public void DescreasePoints()
    {
        currentScore--;
        scoreText.text = "" + currentScore;
    }

    public void ShowEndGame()
    {
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            SavePlayerProgress();
        }
        GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>().text = highestScore.ToString();
        //canvasGroup.alpha = 1;
        //canvasGroup.interactable = true;
        scoreAnimator.SetBool("IsDisplayed",true);
    }

    public void ResetScore()
    {
        //canvasGroup.alpha = 0;
        //canvasGroup.interactable = false;
        scoreAnimator.SetBool("IsDisplayed", false);
        currentScore = 0;
        scoreText.text = ""+currentScore;
    }

    private void LoadPlayerProgress()
    {
        if (PlayerPrefs.HasKey("highestScore"))
        {
            highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestScore", highestScore);
    }
}
