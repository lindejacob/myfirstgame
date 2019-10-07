using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public float speed = 1.0f;
	private Vector3 velocity = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		float forward = 0.0f;
		if (Input.GetButton("Forward"))
        {
			forward = speed;
        }
		else if (Input.GetButton("Back")){
			forward = -1*speed;
		}
        velocity = new Vector3((forward*Time.deltaTime),0,0); 
		transform.position += velocity;
    }
}
