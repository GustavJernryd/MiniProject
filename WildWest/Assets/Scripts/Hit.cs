using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "House")
        {
            Physics.IgnoreLayerCollision(8, 9);
        }

        else
        {
            Debug.Log("hit");
            Destroy(collision.collider.gameObject);
            Destroy(this.gameObject);
        }
    }
           
}
