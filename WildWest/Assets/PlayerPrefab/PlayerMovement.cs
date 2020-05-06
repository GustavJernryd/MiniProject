using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController charCont;
    [SerializeField] private float speed = 4;
    [SerializeField] private bool movableY;

    Vector3 movement;
    Vector2 direction;

    // Update is called once per frame
    void Update()
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
