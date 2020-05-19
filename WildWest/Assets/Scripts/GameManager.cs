using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //[SerializeField] private EnemyAI enemy;
    //[SerializeField] private CharacterController player;
    private GameObject canvas;

    private float timeElapsed, timeLimit;

    public GameState gameState;
    public GameState oldGameState;
    private Text text;
    private bool firstTransition;
    void Awake()
    {
        MakeGameManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        CameraManager.instance.PlayPanningAnimation();
        timeLimit = 3f;
        timeElapsed = 0;
        gameState = GameState.Menu;
        oldGameState = GameState.Menu;
        canvas = GameObject.Find("Canvas_Countdown");
        canvas.SetActive(true);
        foreach (Image i in canvas.GetComponentsInChildren<Image>())
        {
            i.enabled = true;
        }
        canvas.GetComponentInChildren<Text>().enabled = false;
        text = canvas.GetComponentInChildren<Text>();
     }

    void MakeGameManager()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Win()
    {
        gameState = GameState.Menu;
        CameraManager.instance.PlayPanningAnimation();
        foreach (Image i in canvas.GetComponentsInChildren<Image>())
        {
            i.enabled = true;
        }
        Transform t = canvas.transform.Find("WinText");
        t.gameObject.SetActive(true);
    }

    public void Lose()
    {
        gameState = GameState.Menu;
        CameraManager.instance.PlayPanningAnimation();
        foreach (Image i in canvas.GetComponentsInChildren<Image>())
        {
            i.enabled = true;
        }
        Transform t = canvas.transform.Find("LoseText");
        t.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        oldGameState = gameState;
        switch (gameState)
        {
            case GameState.Menu:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    gameState = GameState.Countdown;
                    CameraManager.instance.EndAnimationSequence();
                    firstTransition = true;
                    canvas.GetComponentInChildren<Text>().enabled = true;
                    foreach(Image i in canvas.GetComponentsInChildren<Image>())
                    {
                        i.enabled = false;
                    }
                    Transform tWin = canvas.transform.Find("WinText");
                    tWin.gameObject.SetActive(false);
                    Transform tLose = canvas.transform.Find("LoseText");
                    tLose.gameObject.SetActive(false);
                }
                break;
            case GameState.Countdown:
                if (firstTransition)
                {
                    CameraManager.instance.StartRotateAnimation();
                    firstTransition = false;
                }
                timeElapsed += Time.deltaTime;
                if(timeElapsed < 1)
                {
                    text.text = "3";
                }else if(timeElapsed < 2)
                {
                    text.text = "2";
                }
                else
                {
                    text.text = "1";
                }
                if(timeElapsed >= timeLimit)
                {
                    timeElapsed = 0;
                    gameState = GameState.Running;
                    canvas.GetComponentInChildren<Text>().enabled = false;
                    foreach (Image i in canvas.GetComponentsInChildren<Image>())
                    {
                        i.enabled = false;
                    }
                }
                break;
            case GameState.Running:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    gameState = GameState.Menu;
                    CameraManager.instance.PlayPanningAnimation();
                    foreach (Image i in canvas.GetComponentsInChildren<Image>())
                    {
                        i.enabled = true;
                    }
                }
                break;
        }

    }
}

public enum GameState
{
    Menu,
    Countdown,
    Running
}
