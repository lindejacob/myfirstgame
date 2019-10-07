using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject Player;
    public Transform target;
    public float Camspeed = 0.125f;
    public Vector3 offset;
    // Start is called before the first frame update
    public void Start()
    {  
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        Vector3 DesiredPosition = GameObject.transform + offset;
        Vector3 CameraPosition = Vector3.Lerp(GameObject.transform, DesiredPosition, Camspeed*Time.deltaTime); 
		transform.LookAt(Player.transform);
    }
}
