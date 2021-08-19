using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public RectTransform instructions1;
    public RectTransform instructions2;

    Vector2 instructions1Pos;
    Vector2 instructions2Pos;

    public void OnPlayClick() {

        SceneManager.LoadScene("SampleScene");
    }

    public void OnInstructionsClick()
    {
        instructions1Pos = instructions1.anchoredPosition;
        instructions1.anchoredPosition = Vector3.zero;
    }

    public void OnNextClick()
    {
        instructions2Pos = instructions2.anchoredPosition;
        instructions1.anchoredPosition = instructions1Pos;
        instructions2.anchoredPosition = Vector3.zero;
    }

    public void OnFinishClick()
    {
        instructions2.anchoredPosition = instructions2Pos;
    }
}
