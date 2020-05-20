using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Camera playerCamera;
    public Transform spawnPosition;
    public Animator animator;
    public ParticleSystem muzzleFlash;

    float timeElapsed, reloadTime;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 3;
        reloadTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameState == GameState.Running)
        {
            timeElapsed += Time.deltaTime;
            if (Input.GetMouseButtonDown(0))
            {
                if(timeElapsed > reloadTime)
                {
                    timeElapsed = 0;

                    Cursor.lockState = CursorLockMode.Locked;
                    GameObject bulletObject = Instantiate(bulletPrefab);
                    bulletObject.transform.position = spawnPosition.transform.position;
                    bulletObject.transform.forward = playerCamera.transform.forward;

                    SoundManager.instance.Playvaryingsound("GunShot");
                    muzzleFlash.Play();
                    animator.Play("Fire", 0, 0f);

                }
            }
        }
    }
}
