using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGustav : MonoBehaviour
{
    [SerializeField] private CharacterController charCont;
    [SerializeField] private float speed = 4;
    [SerializeField] private bool movableY;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 180.0f;
    private float pitch = 0.0f;

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

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    
}
