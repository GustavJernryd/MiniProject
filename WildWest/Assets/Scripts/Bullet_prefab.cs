using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float setSpeed;
    [SerializeField] private GameObject bullet;
    public List<GameObject> bullet_List;   //listan som ska callas för att uppdatera alla bullets

    GameObject bullet_prefab;

    private Vector3 spawnPos;
    private float speed;
    void Awake()
    {
        speed = setSpeed;

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }
 
    }

    public void SpawnBullet(GameObject revolverChildObject)
    {

    }


}
