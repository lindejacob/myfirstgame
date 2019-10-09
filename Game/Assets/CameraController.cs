using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject Player;
    public float Camspeed = 1f;
    public Vector3 offset;
    // Start is called before the first frame update
    public void Start()
    {  
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        Vector3 DesiredPosition = Player.transform.position + offset;
        //transform.position = Vector3.MoveTowards(transform.position, DesiredPosition, Camspeed * Time.deltaTime);
        //transform.position = DesiredPosition;
        transform.LookAt(Player.transform);
    }
}
