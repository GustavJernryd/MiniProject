using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("hit player");
            Destroy(this.gameObject);
            ScoreManager.instance.EnemyHit();
        }
        else if (collision.collider.tag.Equals("Enemy"))
        {
            Debug.Log("hit enemy");
            Destroy(this.gameObject);
            ScoreManager.instance.PlayerHit();
        }
        else
        {
            //Physics.IgnoreLayerCollision(8, 9);
            Destroy(this.gameObject);
        }
    }
}
