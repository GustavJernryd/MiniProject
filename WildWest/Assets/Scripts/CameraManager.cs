using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;


    private Animator CameraAnimator;
    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private GameObject CinematicCamera;

    void Awake()
    {
        MakeCameraManager();
    }

    void MakeCameraManager()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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
            PlayPanningAnimation();
        }
    }

    public void StartRotateAnimation()
    {
        PlayerCamera.SetActive(false);
        CinematicCamera.SetActive(true);
        CameraAnimator.Play("Camera_Rotation_Animation",0,0f);
    }

    public void PlayPanningAnimation()
    {
        PlayerCamera.SetActive(false);
        CinematicCamera.SetActive(true);
        CameraAnimator.Play("Camera_Panning_Animation", 0, 0f);
    }

    public void EndAnimationSequence()
    {
        CameraAnimator.StopPlayback();
        PlayerCamera.SetActive(true);
        CinematicCamera.SetActive(false);
    }
}
