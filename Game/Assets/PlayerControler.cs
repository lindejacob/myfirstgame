using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public float speed = 1.0f;
    public GameObject bullet;
	private Vector3 velocity = new Vector3(0,0,0);
    private float lastshoot = 0.0f;
    public float firerate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        lastshoot += Time.deltaTime;
        
        float forward = 0.0f;
        if (Input.GetButton("Forward"))
        {
            forward = speed;
        }
        else if (Input.GetButton("Back"))
        {
            forward = -1 * speed;
        }

        float right = 0.0f;
        if (Input.GetButton("Right"))
        {
            right = speed;
        }
        else if (Input.GetButton("Left"))
        {
            right = -1 * speed;
        }

        if (Input.GetButton("Space") && lastshoot > firerate) { 
            GameObject newBullet = Instantiate(bullet);
            lastshoot -= firerate;
            newBullet.transform.position = transform.position;
            
        }
        velocity = new Vector3((forward*Time.deltaTime),0, right*Time.deltaTime); 
		transform.position += velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}