using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject credits;
    public PlayerStatus game;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        game.StartGame();
        menuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }
}
