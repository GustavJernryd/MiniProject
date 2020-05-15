using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController charCont;
    [SerializeField] private float speed = 4;
    [SerializeField] private bool movableY;

    Vector3 movement, startPosition;
    Vector2 direction;

    void Start()
    {
        startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameState == GameState.Menu && GameManager.instance.oldGameState == GameState.Running)
        {
            transform.position = startPosition;
        }


        if(GameManager.instance.gameState == GameState.Running)
        {
            direction.x = Input.GetAxis("Horizontal");

            if (movableY)
            {
            direction.y = Input.GetAxis("Vertical");
            }   

            movement = new Vector3(direction.x, 0, direction.y);
            charCont.Move(movement * speed * Time.deltaTime);
        }
    }

    
}
