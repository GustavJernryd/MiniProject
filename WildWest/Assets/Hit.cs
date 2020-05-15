using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("hit player");
            GameManager.instance.Win();
            Destroy(this.gameObject);
        }
        else if(collision.collider.tag.Equals("Enemy"))
        {
            Debug.Log("hit enemy");
            //Destroy(collision.collider.gameObject);
            Destroy(this.gameObject);
            GameManager.instance.Win();
        }
        else
        {
            //Physics.IgnoreLayerCollision(8, 9);
            Destroy(this.gameObject);
        }
    }
}
