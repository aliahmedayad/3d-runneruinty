using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI ScoreText;
    public int score;
    public GameObject gameOver;
    public GameObject gameStart;
    private static bool gameStarted =false ; // Flag to track whether the game has started
    SoundManager soundManager;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        // Show the game start UI only if the game hasn't started yet
        if (!gameStarted)
        {
            Time.timeScale = 0;
            gameStart.SetActive(true);
            gameOver.SetActive(false);
            
        }
        else
        {
            ScoreText.gameObject.SetActive(true);
        }
        SoundManager.playSound("Normal");
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + score.ToString();
    }

    public void startGame()
    {
        gameStart.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        Time.timeScale = 1;
        gameStarted = true; // Update the flag to indicate that the game has started
    }

    public void resetLevel()
    {
        gameOver.SetActive(false);
        SoundManager.stopSound(); // Stop any playing sound before resetting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    
}
