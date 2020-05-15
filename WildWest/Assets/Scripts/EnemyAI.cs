using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private MovingState currentState;
    private Vector3 destination, leftBoundary, rightBoundary;
    private float timeElapsed, timeLimit;
    private Vector3 startPosition;
    [SerializeField] private float randomRangeMin;
    [SerializeField] private float randomRangeMax;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        startPosition = transform.position;
        leftBoundary = transform.position;
        leftBoundary.x -= 10;
        rightBoundary = transform.position;
        rightBoundary.x += 7;

        currentState = MovingState.Idle;
        timeElapsed = 0;
        timeLimit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //För testning och första ändring av MovingState. Kommer ersättas av nedräkningen sen.
        if (GameManager.instance.gameState == GameState.Running && GameManager.instance.oldGameState == GameState.Countdown)
        {
            ChangeState();
            print("ChangeState");
        }
        if(GameManager.instance.gameState == GameState.Menu && GameManager.instance.oldGameState == GameState.Running)
        {
            transform.position = startPosition;
            destination = transform.position;
            timeElapsed = 0;
            currentState = MovingState.Idle;
        }


        if(GameManager.instance.gameState == GameState.Running)
        {
            RandomStateChange();

            if(transform.position.x < leftBoundary.x || transform.position.x > rightBoundary.x)
            {
                ChangeState();
                timeElapsed -= timeLimit;
            }

            ChangeDirection();

            transform.position = destination;
        }
    }

    //Flyttar objektet i en riktning beroende på vilket MovingState den är i.
    private void ChangeDirection()
    {
        switch (currentState)
        {
            case MovingState.Idle:
                break;
            case MovingState.Left:
                destination.x -= speed * Time.deltaTime;
                break;
            case MovingState.Right:
                destination.x += speed * Time.deltaTime;
                break;
        }
    }

    //Ändrar MovingState när timeLimit är nådd. timeLimit sätts till en Random float inom Range.
    private void RandomStateChange()
    {
        if (currentState != MovingState.Idle)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed > timeLimit)
            {
                ChangeState();
                timeElapsed -= timeLimit;
                timeLimit = Random.Range(randomRangeMin, randomRangeMax);
            }
        }
    }

    //Ändar MovingState. Flippar MovingState från Left till Right och Right till Left. Om Idle väljs ett Random MovingState.
    public void ChangeState()
    {
        if(currentState == MovingState.Left)
        {
            currentState = MovingState.Right;
        }
        else if(currentState == MovingState.Right)
        {
            currentState = MovingState.Left;
        }
        else
        {
            int randomDecision = Random.Range(0, 2);

            if(randomDecision == 0)
            {
                currentState = MovingState.Left;
            }else if(randomDecision == 1)
            {
                currentState = MovingState.Right;
            }
        }
    }

    //Förflyttelse state.
    public enum MovingState
    {
        Idle,
        Left,
        Right
    }
}
