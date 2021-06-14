using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    private bool scored = false;
    public Transform target;
    private Rigidbody rig;
    public float speed = 20f;

    public AudioSource enermyAudio; 
    public GameObject explosionEffect;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
        enermyAudio = GetComponent<AudioSource>();  
    }
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < 10f)
        { 
            Vector3 tran = target.position - transform.position;
            rig.AddForce(tran * speed * Time.deltaTime); 
        }
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Bullet" && scored == false)
        {
            enermyAudio.Play();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            scored = true;
            GameManager.instance.AddScore(1);
            transform.position = new Vector3(Random.Range(-30, 30), 0.5f, Random.Range(-30, 30));
            scored = false;
           
        } 
    }

}