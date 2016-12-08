﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Rigidbody rig;
    public float speed = 10;
    public float turnSpeed = 200;
    Vector3 dir;
    public GameObject Bullet;
    public GameObject Bullet2;


    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = transform.TransformDirection(new Vector3(0, 0, vAxis) * speed * Time.deltaTime);
        Vector3 currentEuler = transform.eulerAngles;
        currentEuler.y += Time.deltaTime * turnSpeed * hAxis;
        dir = currentEuler;

        rig.MovePosition(transform.position + movement);
        rig.MoveRotation(Quaternion.Euler(dir));

        if (Input.GetButtonDown("ButtonA"))
        {
            Shot();
        }
    }


    public void Shot()
    {
        GameObject BulletF = Instantiate(Bullet, Bullet.transform.parent) as GameObject;
        BulletF.transform.parent = null;
        BulletF.SetActive(true);
        GameObject Bullet2F = Instantiate(Bullet2, Bullet2.transform.parent) as GameObject;
        Bullet2F.transform.parent = null;
        Bullet2F.SetActive(true);
    }
   
}
