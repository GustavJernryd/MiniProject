using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
            Debug.Log("hit");
    }

}
