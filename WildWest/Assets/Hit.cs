using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public static int playerScore = 0;
    public static int enemyScore = 0;
    
    private int winScore = 5;
    public Text textPlayer;
    public Text textEnemy;

    private void ResetScore()
    {
        playerScore = 0;
        enemyScore = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("hit player");
            Destroy(this.gameObject);
            textEnemy = GameObject.Find("OpponentScoreText ").GetComponent<Text>();
            enemyScore++;
            textEnemy.text = enemyScore.ToString();
            if (enemyScore == winScore)
            {
                GameManager.instance.Lose();
            }

        }
        else if (collision.collider.tag.Equals("Enemy"))
        {
            Debug.Log("hit enemy");
            Destroy(this.gameObject);
            textPlayer = GameObject.Find("PlayerScoreText").GetComponent<Text>();
            playerScore++;
            textPlayer.text = playerScore.ToString();
            if (playerScore == winScore)
            {
                GameManager.instance.Win();
            }
        }
        else
        {
            //Physics.IgnoreLayerCollision(8, 9);
            Destroy(this.gameObject);
        }
    }
}
