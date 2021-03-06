﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    Transform target;

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player1_Prefab").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = transform.position - target.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
