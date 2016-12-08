using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Rigidbody rig;
    public float speed = 10;
    public float turnSpeed = 200;
    Vector3 dir;
    public GameObject Bullet;
    public GameObject Bullet2;

    AudioSource saw;

    public AudioClip AIE;


    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
        saw = GameObject.FindObjectOfType<AudioSource>();
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



        Time.timeScale = Mathf.Abs(vAxis) + Mathf.Abs(hAxis)+  0.1f;




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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            saw.PlayOneShot(AIE,0.5f);
        }

    }

}
