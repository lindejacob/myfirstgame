using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour { 
    public float speed = 1.0f;
    private Vector3 velocity = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
    
}


    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(0, 0, speed*Time.deltaTime);
        transform.position += velocity;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }   
}
