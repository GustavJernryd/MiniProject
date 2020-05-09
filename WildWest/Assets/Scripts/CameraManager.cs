using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Animator CameraAnimator;
    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private GameObject CinematicCamera;

    

    // Start is called before the first frame update
    void Start()
    {
        CameraAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartRotateAnimation();
        }
    }

    public void StartRotateAnimation()
    {
        PlayerCamera.SetActive(false);
        CinematicCamera.SetActive(true);
        CameraAnimator.Play("Camera_Rotation_Animation",0,0f);
    }

    public void EndAnimationSequence()
    {  
        PlayerCamera.SetActive(true);
        CinematicCamera.SetActive(false);
    }
}
