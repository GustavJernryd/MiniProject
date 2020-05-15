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

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 180.0f;
    private float pitch = 0.0f;

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
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch += speedV * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

    }

    
}
