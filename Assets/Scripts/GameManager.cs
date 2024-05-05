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
    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        gameStart.SetActive(true);
        gameOver.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text="Score : "+score.ToString();    
    }
    public void startGame()
    {
        gameStart.SetActive(false);
        Time.timeScale = 1;
    }
    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
