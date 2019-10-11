using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    public GameObject Enemy;
    private float offset = 10f;
    public float speed = 1f;
    private Vector3 startPosition;

    public float maxBound { get { return startPosition.x + offset; } }
    public float mindBound { get { return startPosition.x - offset; } }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
        if (transform.position.x > maxBound)
        {
            speed *= -1;
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);

        }
        else if (transform.position.x < mindBound)
        {
            speed *= -1;
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
    }
        
    }

