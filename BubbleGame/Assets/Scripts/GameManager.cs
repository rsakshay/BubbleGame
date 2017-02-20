using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }

    public GameObject BubblePrefab;
    public GameObject startScreen;
    public GameObject endGameScreen;
    public float totalTime;
    public Text ScoreText;
    public Text GameOverText;
    public Text Timer;
    public int score;
    public float bubbleCastDelay;
    public float foodCastDelay;

    float lastBubbleCastTime;
    float gameStartTime;
    int timeLeft;
    bool gameStarted;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    // Use this for initialization
    void Start () {
        gameStarted = false;
        score = 0;
        lastBubbleCastTime = 0.0f;
        ScoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {

        if(gameStarted)
        {
            timeLeft = (int)(totalTime - Time.time + gameStartTime);
            Timer.text = "Time Left: " + timeLeft;
            ScoreText.text = "Score: " + score;

            if (timeLeft > 0)
            {
                if (Input.GetMouseButtonDown(0) && (Time.time - lastBubbleCastTime) > bubbleCastDelay)
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Instantiate(BubblePrefab, new Vector3(mousePos.x, mousePos.y, 0.0f), Quaternion.identity);

                    lastBubbleCastTime = Time.time;
                }
            }
            else
            {
                GameOver();
            }

        }
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameStarted = true;
        gameStartTime = Time.time;
    }

    void GameOver()
    {
        Time.timeScale = 0.0f;
        GameOverText.text = "Your final score is: " + score;
        endGameScreen.SetActive(true);
    }
}
