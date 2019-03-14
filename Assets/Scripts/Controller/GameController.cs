using UnityEngine;

public class GameController : MonoBehaviour {

    private bool life;
    public GameObject gameOver;
    public GameObject reload;

    public bool isPlayerAlive
    {
        get { return life; }
        set { life = value; }
    }

    private void Awake()
    {
        Time.timeScale = 1f;
        life = true;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        reload.SetActive(true);
        Time.timeScale = 0f;
        life = false;
    }
}
