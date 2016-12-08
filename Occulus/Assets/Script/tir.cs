using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tir : MonoBehaviour {

    public GameObject Player;
    public int vitesse = 30;

    private Transform pos;


    private float TimeLife;

    private void Awake()
    {
        pos = gameObject.transform;
    }

    // Use this for initialization
    void Start () {
        transform.LookAt(Player.transform);
	}
	
	// Update is called once per frame
	void Update () {
        TimeLife += Time.deltaTime;
        transform.position = transform.position + transform.forward * Time.deltaTime * vitesse;


        if (TimeLife > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
