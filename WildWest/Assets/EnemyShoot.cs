using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    GameObject player;

    [SerializeField] GameObject bulletPrefab;
    Camera enemyCamera;
    Transform spawnPosition;
    float timeElapsed, timeLimit;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1_Prefab");
        spawnPosition = gameObject.transform.GetChild(7).GetChild(3);
        enemyCamera = gameObject.GetComponentInChildren<Camera>();
        timeElapsed = 0;
        timeLimit = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameState == GameState.Running)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed > timeLimit)
            {
                Fire();
                timeElapsed -= timeLimit;
            }
        }
        
    }

    void Fire()
    {
        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = spawnPosition.transform.position;
        bulletObject.transform.forward = enemyCamera.transform.forward;
    }
}
