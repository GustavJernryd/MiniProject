using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float coolDown;

    private float currentTime;
    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = coolDown;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            currentTime = coolDown;
            ApplyForce();
            Debug.Log("Blow");
        }
    }

    void ApplyForce()
    {
        Vector3 dir;
        dir = new Vector3(Random.Range(-1f, 1f),0f, Random.Range(-1f, 1f));
        rigid.AddForce(dir * force);


    }
}
