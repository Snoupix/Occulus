using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {
    public float speed = 200;
    private float TimeLife;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }


    public void Fire()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        TimeLife += Time.deltaTime;

        if (TimeLife > 4)
        {
            Destroy(gameObject);
        }
    }



}