using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int enemyScore;

    private int scoreToWin;

    private int playerScore;

    private Text textPlayer;
    private Text textEnemy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        textEnemy = GameObject.Find("OpponentScoreText ").GetComponent<Text>();
        textPlayer = GameObject.Find("PlayerScoreText").GetComponent<Text>();

        playerScore = 0;
        enemyScore = 0;
        scoreToWin = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerHit()
    {
        playerScore++;
        textPlayer.text = playerScore.ToString();
        if (playerScore >= scoreToWin)
        {
            playerScore = 0;
            enemyScore = 0;
            textEnemy.text = enemyScore.ToString();
            textPlayer.text = playerScore.ToString();
            GameManager.instance.Win();
        }
    }

    public void EnemyHit()
    {
        enemyScore++;
        textEnemy.text = enemyScore.ToString();
        if(enemyScore >= scoreToWin)
        {
            playerScore = 0;
            enemyScore = 0;
            textEnemy.text = enemyScore.ToString();
            textPlayer.text = playerScore.ToString();
            GameManager.instance.Lose();
        }
    }

    public void ResetScore()
    {
        playerScore = 0;
        enemyScore = 0;
        textEnemy.text = enemyScore.ToString();
        textPlayer.text = playerScore.ToString();
    }
}
