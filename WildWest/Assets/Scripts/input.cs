using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    [SerializeField] GameObject bullet_Prefab;
    [SerializeField] Camera camera;

    List<bullet> bulletList = new List<bullet>();

    GameObject bullet_SpawnObject;
    Vector3 myvec3;

    // Start is called before the first frame update
    void Start()
    {
        bullet_SpawnObject = GameObject.FindGameObjectWithTag("Bullet_SpawnPos_Player1");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate(bullet_Prefab);
            bulletObject.transform.position = bullet_SpawnObject.transform.position + camera.transform.forward;

            //bulletList.Add(new bullet(myvec3, camera.transform.forward));
        }

    }
}
