using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float sf_Bullet_Speed;
    [SerializeField] private GameObject bullet_prefab;
    [SerializeField] private GameObject sf_Player1_Prefab;
    [SerializeField] private GameObject sf_Player2_Prefab;

    float speed;
    private GameObject player1;
    private GameObject player2;

    private GameObject bullet_Object;

    private Vector3 direction;
    private Vector3 bullet_Position;

    public List<GameObject> bulletList;

    Vector3 spawnBulletPos;

    //public bullet(Vector3 spawnPos, Vector3 dir)
    //{
    //    bullet_Object = Instantiate(bullet_prefab);
    //    this.direction = dir;
    //    this.spawnBulletPos = spawnPos;
    //    bullet_Object.transform.position = spawnBulletPos;
    //    transform.Rotate(new Vector3(0 , 90, 0)); // fungerar ej...
    //}

    public void Awake()
    {
        speed = sf_Bullet_Speed;
        //player1 = sf_Player1_Prefab;
        //player2 = sf_Player2_Prefab;

        //spawnbullet_Gameobject = GameObject.FindGameObjectWithTag("Bullet_SpawnPos_Player1");
    }

    public void Update()
    {
        transform.position +=  new Vector3(0,0,-1) * speed * Time.deltaTime;

    }


}
