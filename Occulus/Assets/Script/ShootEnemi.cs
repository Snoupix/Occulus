using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemi : MonoBehaviour {


    public float delay = 0.5f;

    private float timer, timerRef;

    public GameObject Bullet;

    private void Awake()
    {
        timer = 0; timerRef = 0;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= timerRef + delay)
        {
            GameObject BulletSpawn = Instantiate(Bullet, Bullet.transform.parent) as GameObject;
            BulletSpawn.transform.parent = null;
            BulletSpawn.SetActive(true);
            timerRef += delay;
        }
        if(timer >= 3000)
        {
            timer = 0;
            timerRef = 0;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MBullet")
        {
            Destroy(gameObject);
        }

    }

}
